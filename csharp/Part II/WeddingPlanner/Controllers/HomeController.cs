using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        private User ActiveUser
        {
            get { return _context.users.Where(u => u.user_id == HttpContext.Session.GetInt32("id")).FirstOrDefault(); }
        }
        private User ActiveUserDetailed
        {
            get
            {
                return _context.users
               .Where(u => u.user_id == HttpContext.Session.GetInt32("id"))
               .FirstOrDefault();
            }
        }
        public HomeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.users.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Register(NewUser newUser)
        {
            PasswordHasher<NewUser> hasher = new PasswordHasher<NewUser>();
            if (_context.users.Where(u => u.email == newUser.Email).SingleOrDefault() != null)
                ModelState.AddModelError("Username", "Username in use");
            if (ModelState.IsValid)
            {
                User User = new User
                {
                    first_name = newUser.FirstName,
                    last_name = newUser.LastName,
                    email = newUser.Email,
                    password = hasher.HashPassword(newUser, newUser.Password),
                };
                User theUser = _context.Add(User).Entity;
                _context.SaveChanges();

                HttpContext.Session.SetInt32("id", theUser.user_id);
                return RedirectToAction("Index", "Wedding");
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult Login(LogUser logUser)
        {
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            User userToLog = _context.users.Where(u => u.email == logUser.LogEmail).SingleOrDefault();
            if (userToLog == null)
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
            else if (hasher.VerifyHashedPassword(logUser, userToLog.password, logUser.LogPassword) == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
            }
            if (!ModelState.IsValid)
                return View("Index");
            HttpContext.Session.SetInt32("id", userToLog.user_id);
            return RedirectToAction("Index", "Wedding");
        }
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult Show(int id)
        {
            if (HttpContext.Session.GetInt32("id") == null ||
               HttpContext.Session.GetInt32("id") != id)
                return RedirectToAction("Index");
            return View(this.ActiveUser);
        }

    }
}