using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NLog;
using NLog.Web;
using System;
using System.IO;

namespace DotNetCore.API
{

    /// <summary>
    /// Reference NLog: https://github.com/NLog/NLog.Web/issues/213
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var configuringFileName = "nlog.config";

            //If we inspect the Hosting aspnet code, we'll see that it internally looks the 
            //ASPNETCORE_ENVIRONMENT environment variable to determine the actual environment
            var aspnetEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var environmentSpecificLogFileName = $"nlog.{aspnetEnvironment}.config";

            if (File.Exists(environmentSpecificLogFileName))
            {
                configuringFileName = environmentSpecificLogFileName;
            }

            // NLog: setup the logger first to catch all errors
            var logger = NLogBuilder.ConfigureNLog(configuringFileName).GetCurrentClassLogger();
            try
            {
                logger.Debug("Application started");
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
                var sharedFolder = Directory.GetCurrentDirectory().ToString();

                var configuration = new ConfigurationBuilder()
                    //.AddJsonFile(Path.Combine(sharedFolder, "sharedsettings.json"), optional: false, reloadOnChange: true)
                    .AddJsonFile("sharedsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environment}.json", optional: true)
                    .Build();

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, $"Stopped program because of exception. Error: {JsonConvert.SerializeObject(ex)}");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    //Require "UseIISIntegration" to host in IIS as per stackoverflow suggestion but I didn't find that it is require.
                    //webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseNLog();
                });
    }
}
