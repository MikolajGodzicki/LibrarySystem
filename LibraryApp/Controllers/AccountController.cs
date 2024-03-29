using Elfie.Serialization;
using LibraryApp.Entities;
using LibraryApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryApp.Controllers {
    public class AccountController : BaseAuthenticatorController {
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager) : base(userManager, signInManager) {
        }

        //GET: Login
        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        //POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel) {
            if (!ModelState.IsValid) {
                return View(userLoginModel);
            }

            var result = await _signInManager.PasswordSignInAsync(userLoginModel.UserName, userLoginModel.Password, false, false);

            if (!result.Succeeded) {
                ViewBag.LoginError = "Nie znaleziono konta z takimi danymi!";
                return View();
            }

            return RedirectToHome();
        }

        //GET: Register
        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        //POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel userRegisterModel) {
            if (!ModelState.IsValid) {
                return View(userRegisterModel);
            }

            var checkUserName = await _userManager.FindByNameAsync(userRegisterModel.UserName);
            if (checkUserName is not null) {
                ViewBag.UserNameValidationError = "Konto z taką nazwą istnieje";
                return View();
            }

            var checkEmail = await _userManager.FindByEmailAsync(userRegisterModel.Email);
            if (checkEmail is not null) {
                ViewBag.EmailValidationError = "Konto z takim E-Mailem istnieje";
                return View();
            }

            var checkPasswords = userRegisterModel.Password.Equals(userRegisterModel.ConfirmPassword);
            if (!checkPasswords) {
                ViewBag.PasswordConfirmValidationError = "Hasła się różnią";
                return View();
            }

            var _newUser = new User() {
                UserName = userRegisterModel.UserName,
                Email = userRegisterModel.Email
            };

            await _userManager.CreateAsync(_newUser, userRegisterModel.Password);

            return RedirectToHome();
        }

        [HttpGet]
        public async Task<IActionResult> Details() {
            var user = await _userManager.GetUserAsync(User);

            if (user is null) {
                return NotFound();
            }

            return View(user);
        }



        //POST: Logout
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToLogin();
        }
    }
}
