using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practice.Models;
using DbConnection;

namespace practice.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            //List<Dictionary<string, objects>>
            var friends = DbConnector.Query("SELECT * FROM user");

            ViewBag.Friends = friends;

            // Friend myFriend = new Friend()
            // {
            //     first_name = "Jackie",
            //     last_name = "Chan",
            //     email = "jackie@test.com",
            //     age = 65
            // };

            return View();
        }

        [HttpPost("posting")]
        public IActionResult Post (Friend friend)
        {
            //friend.name
            //friend.location
            return Json(friend);
        }
    }
}
