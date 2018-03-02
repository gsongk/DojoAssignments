using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace password.Controllers
{
    public class PasswordController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            int? RunCount = HttpContext.Session.GetInt32("RunCount");
            if (RunCount == null)
            {
                RunCount = 0;
            }
            RunCount += 1;
            string PossibleCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string PassCode = "";
            Random Rand = new Random();
            for (int i = 0; i < 14; i++)
            {
                PassCode = PassCode + PossibleCharacters[Rand.Next(0, PossibleCharacters.Length)];
            }
            ViewBag.PassCode = PassCode;
            ViewBag.RunCount = RunCount;
            HttpContext.Session.SetInt32("RunCount", (int)RunCount);
            return View();
        }
    }
}