using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
