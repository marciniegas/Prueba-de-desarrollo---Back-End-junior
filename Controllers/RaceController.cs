using Microsoft.AspNetCore.Mvc;

namespace Bovinos.Controllers
{
    public class RaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
