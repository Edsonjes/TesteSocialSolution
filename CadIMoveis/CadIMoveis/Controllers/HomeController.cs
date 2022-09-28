using Microsoft.AspNetCore.Mvc;

namespace CadIMoveis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
