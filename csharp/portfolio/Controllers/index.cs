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

        [HttpGet("projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [HttpGet("contacts")]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}