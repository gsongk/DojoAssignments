using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Secrets.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Secrets.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        // GET: /Home/
        public HomeController(MyContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
