using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class index : Controller
    {
        [HttpGet("")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet("Projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [HttpGet("Contacts")]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}