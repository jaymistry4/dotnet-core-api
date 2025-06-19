using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers.V3
{
    [ApiVersion("3.0")]
    [ApiExplorerSettings(GroupName = "v3")]
    [Route("api/v{version:apiversion}/[controller]")]
    public class SessionTestApiController : ControllerBase
    {
        /// <summary>
        /// For UseSession middleware (UseSession)
        /// GET https://localhost:5001/api/v3/SessionTestApi/set-session/Jay
        /// → Sets session data.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("set/{name}")]
        public IActionResult SetSession(string name)
        {
            Request.HttpContext.Session.SetString("username", name);
            return Ok($"Session value set to: {name}");
        }

        /// <summary>
        /// GET https://localhost:5001/api/v3/SessionTestApi/get-session
        /// → Retrieves it from session.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult GetSession()
        {
            var value = Request.HttpContext.Session.GetString("username") ?? "Not set";
            return Ok($"Session value is: {value}");
        }

        /// <summary>
        /// For Response caching example and middleware (UseResponseCaching)
        /// GET https://localhost:5001/api/v3/SessionTestApi/time
        /// → You'll get same result if you hit again within 30 seconds.
        /// </summary>
        /// <returns></returns>
        [HttpGet("time")]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult GetTime()
        {
            return Ok($"Server Time: {DateTime.Now}");
        }
    }
}