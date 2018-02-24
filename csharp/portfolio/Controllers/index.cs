using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class index : Controller
    {
        [HttpPost("")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost("Projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [HttpPost("Contacts")]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}