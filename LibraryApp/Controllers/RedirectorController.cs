using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers {
    public class RedirectorController : Controller {

        protected IActionResult RedirectToLogin() => RedirectToAction("Login", "Account");

        protected IActionResult RedirectToHome() => RedirectToAction("Index", "Home");
    }
}
