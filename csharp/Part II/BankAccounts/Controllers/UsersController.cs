using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using BankAccounts.Models;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class UsersController : Controller
    {
        private BankAccountContext _context;
        public UsersController(BankAccountContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("registerUser")]
        public IActionResult CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User user = new User();
                user.Password = Hasher.HashPassword(user, model.Password);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
                int UserId = _context.Users.Last().Id;
                HttpContext.Session.SetInt32("UserId", UserId);
                return Redirect($"/account/{UserId}");
            }
            return View("Register", model);
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("loginUser")]
        public IActionResult LoginUser(string Email, string Password)
        {
            User user = _context.Users.Where(u => u.Email == Email).SingleOrDefault();
            if (user != null && Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password))
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return Redirect($"/account/{user.Id}");
                }
            }
            TempData["Error"] = "Invalid Email/Password Combination";
            return View("Login");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}