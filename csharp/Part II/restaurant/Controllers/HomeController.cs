using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using restaurant.Models;

namespace restaurant.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _c;
        public HomeController(ReviewContext context)
        {
            _c = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("post")]
        public IActionResult Post(Review review)
        {
            System.Console.WriteLine("***********************************************************************came to POST");
            System.Console.WriteLine(review.restaurrant);
            System.Console.WriteLine(review.name);
            System.Console.WriteLine(review.rev);
            System.Console.WriteLine(review.review_date);
            Review newReview = new Review()
            {
                restaurrant = "Place 2",
                name = "reviewer 5",
                rev = "average to bad  food",
                stars = 2,
                review_date = DateTime.Now,
            };
            _c.Add(newReview);
            _c.SaveChanges();
            // Trying to work with just base commands
            _c.Add(review);
            _c.SaveChanges();
            return Redirect("Reviews");
        }

        [HttpGet("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _c.Reviews.ToList();
            ViewBag.AR = AllReviews;
            return View();
        }
    }
}