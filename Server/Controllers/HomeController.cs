using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
