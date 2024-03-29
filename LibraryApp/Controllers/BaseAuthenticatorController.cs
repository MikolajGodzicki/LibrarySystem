using LibraryApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BaseAuthenticatorController : RedirectorController {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        
        public BaseAuthenticatorController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
    }
}
