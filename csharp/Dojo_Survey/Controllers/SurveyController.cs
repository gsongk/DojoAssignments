using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dojo_Survey.Controllers
{
    public class Dojo_Survey: Controller
    {
        [HttpPost("")]
        public IActionResult Home(string name, string comment)
        {
            return View();
        }

        [HttpGet]
        [Route("review")]
        public IActionResult review()
        {
            return View();
        }
    }
}