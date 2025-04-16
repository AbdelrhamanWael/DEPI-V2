using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DEPI_V2.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity?.Name != "admin@depi.com")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
} 