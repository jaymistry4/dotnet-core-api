using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetCore.API.Controllers.BaseControllers
{
    [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, type: typeof(string), description: "Bad request.")]
    [SwaggerResponse(statusCode: StatusCodes.Status401Unauthorized, type: typeof(string), description: "Unauthorized.")]
    [SwaggerResponse(statusCode: StatusCodes.Status403Forbidden, type: typeof(string), description: "Forbidden.")]
    [SwaggerResponse(statusCode: StatusCodes.Status417ExpectationFailed, type: typeof(string), description: "Application error.")]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(string), description: "Internal server error.")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
