using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Password.Controllers
{
    public class Password : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}