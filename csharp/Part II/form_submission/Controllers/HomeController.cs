using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string first_name, string last_name, string email, int age, string password)
        {
            User NewUser = new User
            {
                FirstName = first_name,
                LastName = last_name,
                Email = email,
                Age = age,
                Password = password
            };

            // validation fails, redirect back to form
            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                return View();
            }
            // otherwise validation passes, redirect to success
            else
            {
                return RedirectToAction("Success");
            }

        }

        [HttpGet]
        [Route("/success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
