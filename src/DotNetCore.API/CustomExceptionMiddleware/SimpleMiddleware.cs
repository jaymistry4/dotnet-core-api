namespace DotNetCore.API.CustomExceptionMiddleware
{
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Pre-processing logic
            await _next(httpContext); //call next middleware
            //Post-processing logic

        }
    }
}