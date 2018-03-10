using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginRegistrationII.Models;

namespace LoginRegistrationII.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("signup")]
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(user user)
        {
            string checkEmail = $"SELECT user_id FROM users WHERE email = '{user.email}'";
            if (DbConnector.Query(checkEmail).Count > 0)
                ModelState.AddModelError("email", "Email already in use");

            if (ModelState.IsValid)
            {
                // Hash user's password for DB storage
                PasswordHasher<user> hasher = new PasswordHasher<user>();
                string hashedPW = hasher.HashPassword(user, user.password);

                string createUser = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                    VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedPW}', NOW(), NOW());";
                DbConnector.Execute(createUser);
                TempData["success"] = "Thanks for registering!";
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser user)
        {
            //login the user
            // check that email is in the database

            // query db for user with email
            string checkEmail = $"SELECT user_id, password FROM users WHERE email = '{user.email}'";
            var userToLog = DbConnector.Query(checkEmail).FirstOrDefault();
            if (userToLog == null)
                ModelState.AddModelError("email", "Invalid Email/Password");
            else
            {
                string hashedFromDB = (string)userToLog["password"];
                PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                // check hashed password for user with email
                // if VerifyHashedPassword evaluates to 0, we have a fail!
                // or even better, evaluate to the status of PasswordVerificationResult
                if (hasher.VerifyHashedPassword(user, hashedFromDB, user.password) ==
                    PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");
                }
            }
            if (ModelState.IsValid)
            {
                // Log the user in!
                HttpContext.Session.SetInt32("id", (int)userToLog["user_id"]);
                TempData["success"] = "You have succsessfully logged in!";
                return RedirectToAction("Success");
            }
            return View("LoginView");
        }
        [HttpGet("success")]
        public IActionResult Success()
        {
            // make sure user is logged here!
            if (HttpContext.Session.GetInt32("id") == null)
            {
                TempData["failure"] = "Unauthorized user!!";
                return RedirectToAction("LoginView");
            }
            return View();
        }
    }
}