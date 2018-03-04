using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostInTheWoods.Factories;
using LostInTheWoods.Models;
using Microsoft.AspNetCore.Mvc;


namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private TrailsFactory _trailQuery;

        public HomeController(TrailsFactory trailQuery)
        {
            _trailQuery = trailQuery;
        }

        public IActionResult Index()
        {
            var result = _trailQuery.GetTrails();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trail trail)
        {
            _trailQuery.CreateTrail(trail);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Show(int id)
        {
            var result = _trailQuery.GetTrailById(id);
            return View(result);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _trailQuery.GetTrailById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Trail trail)
        {
            _trailQuery.UpdateTrail(trail);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _trailQuery.deleteTrail(id);
            return RedirectToAction("Index");
        }
    }
}