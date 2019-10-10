using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers
{
    public class JQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}