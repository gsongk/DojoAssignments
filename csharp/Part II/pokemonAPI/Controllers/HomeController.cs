using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pokemonAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            System.Console.WriteLine("index page");
            return View();
        }

        [HttpGet("request/{Pokeid}")]
        public IActionResult QueryPoke(int Pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(Pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();
            // Other code
            System.Console.WriteLine("request page");
            System.Console.WriteLine(PokeInfo);
            return RedirectToAction("");
        }
    }
}