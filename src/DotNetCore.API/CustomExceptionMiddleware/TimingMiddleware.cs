using System.Diagnostics;

namespace DotNetCore.API.CustomExceptionMiddleware
{
    public class TimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TimingMiddleware> _logger;
        public TimingMiddleware(RequestDelegate next, ILogger<TimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                //Pre-processing logic
                await _next(httpContext); //call next middleware
                //Post-processing logic
            }
            finally
            {
                sw.Stop();
                _logger.LogInformation(">>>>> Request {Method} {Path} took {ElapsedMs}ms",
                    httpContext.Request.Method,
                    httpContext.Request.Path,
                    sw.ElapsedMilliseconds);
            }
        }
    }
}