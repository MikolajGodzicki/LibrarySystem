using Elfie.Serialization;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace LibraryApp.Controllers
{
    public class AccountController : BaseAuthenticatorController
    {
        public AccountController(LibraryDbContext context) : base (context)
        {
        }

        //GET: Register
        public IActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("UserID,Username,Password,ConfirmPassword,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Users.FirstOrDefault(s => s.Email == user.Email);
                if (check == null)
                {
                    user.Password = GetMD5(user.Password);
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToHome();
                }
                else
                {
                    ViewBag.error = "Konto z takim E-Mailem istnieje";
                    return View();
                }

            }

            return View();
        }

        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("UserID,Username,Password")] UserDTO user)
        {
            if (ModelState.IsValid)
            {
                string Username = user.Username;
                string Password = user.Password;

                var HashedPassword = GetMD5(Password);
                var data = _context.Users.Where(s => s.Username.Equals(Username) && s.Password.Equals(HashedPassword)).ToList();
                if (data.Count() > 0)
                {
                    HttpContext.Session.SetInt32("UserID", data.First().UserID);
                    return RedirectToHome();
                }
                else
                {
                    ViewBag.error = "Błędne dane"; 
                    return View();
                }
            }
            return View();
        }


        //POST: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToLogin();
        }

        public IActionResult Details()
        {
            User _user = GetUser();
            ViewData["IsAuthenticated"] = IsUserAuthenticated();
            ViewData["Username"] = _user.Username;
            return View(_user);
        }

        public static string GetMD5(string str)
        {
            using (var md5Hash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(str);

                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                return hash;
            }
        }
    }
}
