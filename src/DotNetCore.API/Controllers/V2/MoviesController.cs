using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/v{version:apiversion}/[controller]")]
    [Authorize(Policy = "Member")]
    public class MoviesController : Controller
    {
        [HttpGet]
        [Route("movies")]
        public IActionResult Get()
        {
            //return Content("List of Movies");

            var dict = new Dictionary<string, string>();
            HttpContext.User.Claims.ToList().ForEach(item => dict.Add(item.Type, item.Value));

            return Ok(dict);
        }
    }
}