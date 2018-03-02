using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string allQuotes = "SELECT * FROM quotes";
            var quotes = DbConnector.Query(allQuotes);
            if (quotes != null)
            {
                ViewBag.AQ = quotes;
            }
            else
            {
                string noQuotes = "No Quotes";
                ViewBag.AQ = noQuotes;
            }
            return View();
        }

        [HttpGet("/quotes")]
        public IActionResult Quotes()
        {
            return View();
        }

        [HttpPost("/post")]
        public IActionResult Post(string author, string content, string typee)
        {
            switch (typee)
            {
                case "form1":
                    System.Console.WriteLine("this was form1");
                    break;

                default:
                    System.Console.WriteLine("this was form2");
                    break;
            }
            if (author == null)
            {
                HttpContext.Session.SetString("Author", "Author cannot be blank");
                System.Console.WriteLine("Author cannot be blank");
                return RedirectToAction("Error");
            }
            if (content == null)
            {
                HttpContext.Session.SetString("Content", "Content cannot be blank");
                System.Console.WriteLine("Content cannot be blank");
                return RedirectToAction("Error");
            }

            string addQuote = $"INSERT INTO quotes (author, content, created_at, updated_at) VALUE ('{author}', '{content}', now(), now())";
            DbConnector.Execute(addQuote);
            return RedirectToAction("Index");
        }

        [HttpGet("/errors")]
        public IActionResult Error()
        {
            List<string> mistakes = new List<string>();
            mistakes.Add(HttpContext.Session.GetString("Content"));
            mistakes.Add(HttpContext.Session.GetString("Author"));
            ViewBag.Mistakes = mistakes;
            return View();
        }
    }
}