using Microsoft.AspNetCore.Mvc;

namespace FINAL_ASSIGNMENT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
            {
                return View();
            }
        }
}
