using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;

namespace TheWall.Controllers
{
    public class UserController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("submit")]
        public IActionResult Register(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                RegisterUser(user);
                return RedirectToAction("Index", "Wall");
            }
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser user)
        {
            List<Dictionary<string, object>> users = DbConnector.Query($"SELECT id, password FROM users WHERE email = '{user.LogEmail}'");

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            //user exists
            if ((users.Count == 0 || user.LogPassword == null) || hasher.VerifyHashedPassword(user, (string)users[0]["password"], user.LogPassword) == 0)
            {
                // we are bad
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
            }
            if (ModelState.IsValid)
            {
                // go somewhere cool.  login user to session
                HttpContext.Session.SetInt32("id", (int)users[0]["id"]);
                return RedirectToAction("Index", "Wall");
            }
            return View("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public void RegisterUser(RegisterUser user)
        {
            PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
            string hashed = hasher.HashPassword(user, user.Password);

            string query = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                            VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{hashed}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
            HttpContext.Session.SetInt32("id", Convert.ToInt32(DbConnector.Query(query)[0]["id"]));
        }
    }
}