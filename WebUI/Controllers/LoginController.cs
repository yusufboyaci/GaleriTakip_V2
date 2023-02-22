using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
