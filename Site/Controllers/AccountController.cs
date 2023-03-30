using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
