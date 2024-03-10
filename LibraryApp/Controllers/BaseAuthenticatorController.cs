using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BaseAuthenticatorController : Controller
    {
        protected readonly LibraryDbContext _context;
        
        public BaseAuthenticatorController(LibraryDbContext context)
        {
            _context = context;
        }

        protected bool IsUserAuthenticated() => HttpContext.Session.GetInt32("UserID") != null;

        protected IActionResult RedirectToLogin() => RedirectToAction("Login", "Account");

        protected IActionResult RedirectToHome() => RedirectToAction("Index", "Home");
    }
}
