using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloASP.Controllers
{
    public class HelloController : Controller
    {

        // :5000
        [HttpGet("")] 
        public IActionResult Index()
        {
            ViewBag.Hello = new int[]
            {
                123,
                123125,
                13541654,
            };
            return View();
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            ViewBag.Hello = new int[]
            {
                3455,
                23455,
                5613454,
            };
            return Json(ViewBag.Hello);
        }
    }
}