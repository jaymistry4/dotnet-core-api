using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.API.Controllers
{
    [Authorize(Policy = "Member")]
    [Route("api/v1/[controller]")]
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