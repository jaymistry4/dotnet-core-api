using DotNetCore.API.Controllers.BaseControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DotNetCore.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class ApiVersionSampleController : BaseController
    {
        public ApiVersionSampleController(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(configuration, httpContextAccessor)
        {

        }

        [Route("TestApiVersion")]
        [HttpGet]
        [SwaggerOperation("This is test method.", Tags = new[] { "ApiVersioning" })]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string), description: "This is okay response.")]
        //[Authorize(Policy = "Member")]
        public async Task<IActionResult> Get()
        {
            return StatusCode(StatusCodes.Status200OK, "It is working.");
        }
    }
}
