using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dojo_Survey.Controllers
{
    public class Dojo_Survey: Controller
    {
        [HttpGet("")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost("review")]
        public IActionResult Review(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            
            return View();
        }
    }
}