using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Secrets.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(NewUser user)
        {
            // Check uniqueness of user's email
            if (_context.users.SingleOrDefault(u => u.email == user.email) != null)
                ModelState.AddModelError("email", "Email already exists");

            if (ModelState.IsValid)
            {
                // Create User
                PasswordHasher<User> hasher = new PasswordHasher<User>();

                // setting the user's password field to hashed string of the form's plaintext password
                User toCreate = new User()
                {
                    first_name = user.first_name,
                    last_name = user.last_name,
                    email = user.email,
                    password = hasher.HashPassword(user, user.password)
                };

                _context.users.Add(toCreate);
                _context.SaveChanges();

                // Log NewUser into Session
                HttpContext.Session.SetInt32("id", (int)toCreate.user_id);

                return RedirectToAction("Index", "Secret");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            // Check if email exists
            if (_context.users.SingleOrDefault(u => u.email == user.logEmail) == null)
                ModelState.AddModelError("logEmail", "Invalid Email/Password");
            else
            {

                // get user with email from form, for retrieving hashed pw
                User toCheck = _context.users.SingleOrDefault(u => u.email == user.logEmail);
                // Check User's Password
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

                // if VerifyHashedPassword returns a Failure, we can check that against 0
                if (hasher.VerifyHashedPassword(user, toCheck.password, user.logPassword) == 0)
                {
                    ModelState.AddModelError("logEmail", "Invalid Email/Password");
                }
            }
            if (ModelState.IsValid)
            {
                // get user with email from form, for retrieving hashed pw
                User userToLog = _context.users.SingleOrDefault(u => u.email == user.logEmail);

                // Log User into Session
                HttpContext.Session.SetInt32("id", (int)userToLog.user_id);

                return RedirectToAction("Index", "Secret");
            }
            return View("Index");
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



    }
}