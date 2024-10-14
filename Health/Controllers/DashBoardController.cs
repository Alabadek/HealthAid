using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
