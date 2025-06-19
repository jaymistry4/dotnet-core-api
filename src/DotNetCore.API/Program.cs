using AspNetCoreRateLimit;
using Data.Model;
using DotNetCore.API.CustomExceptionMiddleware;
using DotNetCore.API.Extensions;
using DotNetCore.API.Models;
using EncryptionDecryption;
using Fiver.Security.Bearer.Helpers;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using MongoDBUtility.Context;
using MongoDBUtility.Interface;
using NLog;
using NLog.Web;
using System.Reflection;

var configuringFileName = "nlog.config";
var aspnetEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var environmentSpecificLogFileName = $"nlog.{aspnetEnvironment}.config";

if (File.Exists(environmentSpecificLogFileName))
    configuringFileName = environmentSpecificLogFileName;

// Configure NLog
var logger = NLogBuilder.ConfigureNLog(configuringFileName).GetCurrentClassLogger();
try
{
    logger.Debug("Application started");

    var builder = WebApplication.CreateBuilder(args);

    // Load extra configs
    builder.Configuration
        .AddJsonFile("sharedsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true)
        .AddJsonFile($"appsettings.{aspnetEnvironment}.json", optional: true)
        .AddEnvironmentVariables();

    // NLog Setup
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Host.UseNLog();

    var services = builder.Services;
    var configuration = builder.Configuration;

    // Add services to the container
    services.AddControllersWithViews().AddRazorRuntimeCompilation();

    // CORS
    services.AddCors(options =>
    {
        options.AddPolicy("MyBlogPolicy", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });

    // JWT
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Fiver.Security.Bearer",
                    ValidAudience = "Fiver.Security.Bearer",
                    IssuerSigningKey = JwtSecurityKey.Create("fiver-secret-key")
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });

    services.AddAuthorization(options =>
    {
        options.AddPolicy("Member", policy => policy.RequireClaim("MembershipId"));
    });

    // DbContext
    services.AddDbContext<WideWorldImportersDbContext>(options =>
    {
        options.UseSqlServer(configuration["AppSettings:ConnectionString"]);
    });

    services.Configure<Mongosettings>(options =>
    {
        options.ConnectionBook = configuration["MongoSettings:ConnectionBook"];
        options.Connection = configuration["MongoSettings:Connection"];
        options.DatabaseName = configuration["MongoSettings:DatabaseName"];
    });

    services.AddSingleton<ILoggerManager, LoggerManager>();
    services.AddTransient<IMongoDBUtilityContext, MongoDBUtilityContext>();
    services.AddTransient<IEncryptDecrypt, EncryptDecrypt>();

    // Swagger
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "WideWorldImporters API", Version = "v1" });
        options.SwaggerDoc("v2", new OpenApiInfo { Title = "WideWorldImporters API", Version = "v2" });
        options.SwaggerDoc("v3", new OpenApiInfo { Title = "HttpClient Examples API", Version = "v3" });
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    #region Named Client

    services.AddHttpClient("NamedClient", client =>
    {
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
        client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpClientFactory");
    });

    services.AddHttpClient("EmailApiNamedClient", client =>
    {
        client.BaseAddress = new Uri("https://dummyjson.com");
        client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpClientFactory");
    });

    #endregion

    // Rate Limiting
    services.AddMemoryCache();
    services.Configure<IpRateLimitOptions>(options =>
    {
        options.EnableEndpointRateLimiting = true;
        options.StackBlockedRequests = false;
        options.HttpStatusCode = 429;
        options.RealIpHeader = "X-Real-IP";
        options.ClientIdHeader = "X-ClientId";
        options.GeneralRules = new List<RateLimitRule>
        {
            new RateLimitRule { Endpoint = "*", Period = "10s", Limit = 10 },
            new RateLimitRule { Endpoint = "GET:/employee/getAllEmployees", Period = "10s", Limit = 2 }
        };
    });

    services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
    services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
    services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
    services.AddInMemoryRateLimiting();

    services.AddApiVersioning(config =>
    {
        config.DefaultApiVersion = new ApiVersion(1, 0);
        config.AssumeDefaultVersionWhenUnspecified = true;
        config.ReportApiVersions = true;
    });

    #region Session Services

    // Add session services
    services.AddDistributedMemoryCache(); // Required for session

    //By default, session size is limited to 20KB.You can change this with: 
    services.AddSession(options =>
    {
        //options.Cookie.Name = "MyApp.Session";
        options.IdleTimeout = TimeSpan.FromMinutes(5);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    #endregion

    #region Response Caching

    // Add response caching services
    services.AddResponseCaching();

    #endregion

    //////////////////////////////////////////////////////////////////////////////////
    // App builder starts
    //////////////////////////////////////////////////////////////////////////////////

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), $"nlog.{app.Environment.EnvironmentName}.config"));
    LogManager.Configuration.Variables["connectionString"] = configuration["AppSettings:ConnectionString"];
    LogManager.KeepVariablesOnReload = true;
    LogManager.Configuration.Reload();

    #region Custom Middleware

    //Simple middleware registration
    app.UseMiddleware<SimpleMiddleware>();
    app.UseMiddleware<TimingMiddleware>();

    //Convention-based registration
    app.ConfigureCustomExceptionMiddleware();

    //In-line middleware (great for simple case)
    app.Use(async (context, next) =>
    {
        await next(); // Pass to the next middleware               
    });

    //In-line middleware (Checking request path and perform some operation)
    app.Use(async (context, next) =>
    {
        var path = context.Request.Path;
        if (path.StartsWithSegments("/custom"))
            await context.Response.WriteAsync("Custom path matched: " + path);
        else
            await next();
    });

    #endregion

    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseCors("MyBlogPolicy");

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "All API V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Dotnet Core API V2");
        options.SwaggerEndpoint("/swagger/v3/swagger.json", "HttpClient Examples API V3");
    });

    app.UseHttpsRedirection();

    //The issue where HttpContext.Session is null typically occurs because session middleware isn't properly configured or the session isn't being initialized. Here's how to fix it:
    // Add this middleware BEFORE UseRouting() and AFTER UseHttpsRedirection(), 
    app.UseSession();             // Enables session support // This must come after UseRouting


    app.UseRouting();
    app.UseIpRateLimiting();
    app.UseAuthorization();

    // Use response caching middleware
    app.UseResponseCaching();     // Enables response caching

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });

    //Map method example
    app.Map("/map", mappedApp =>
    {
        mappedApp.Use(async (context, next) =>
        {
            Console.WriteLine("Mapped middleware to /map");
            await context.Response.WriteAsync("Hello from the /map path");
            await next();
        });
    });

    //This handles any request that wasn't handled earlier in the pipeline.
    app.Run(async context =>
    {
        await context.Response.WriteAsync("This will catch all unmatched paths.");
    });

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, $"Stopped program because of exception: {ex.Message}");
    throw;
}
finally
{
    LogManager.Shutdown();
}
