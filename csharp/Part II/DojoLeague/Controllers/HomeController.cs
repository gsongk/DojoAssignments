using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


namespace DojoLeague.Controllers
{
    public class HomeController : Controller
    {
        private DataFactory _data;

        public HomeController(DataFactory data)
        {
            _data = data;
        }

        public IActionResult Ninjas()
        {
            var ninjas = _data.GetNinjas();
            var dojos = _data.GetDojos();
            return View(new DojoLeagueViewModel() { Ninjas = ninjas, Dojos = dojos });
        }

        public IActionResult Dojos()
        {
            return View(new DojosViewModel { dojos = _data.GetDojos() });
        }

        [HttpPost]
        public IActionResult CreateNinja(Ninja ninja)
        {
            _data.AddNinja(ninja);
            return RedirectToAction("Ninjas");
        }

        [HttpPost]
        public IActionResult CreateDojo(Dojo dojo)
        {
            _data.AddDojo(dojo);
            return RedirectToAction("Dojos");
        }

        //        public IActionResult ShowDojo(int id)
        //        {
        //            var result =_data.GetDojoById(id);
        //            return View(result);
        //        }
        public IActionResult ShowNinja(int id)
        {
            var result = _data.GetNinjaById(id).ToList();
            return View(result);
        }
        public IActionResult ShowDojo(int id)
        {
            try
            {
                var result = _data.GetDojoById(id);
                return View(result);
            }
            catch (NullReferenceException e)
            {
                TempData["msg"] = "No one registered for that location!";
                return RedirectToAction("Ninjas");

            }
        }

        public IActionResult UpdateDojo(int id, int back)
        {
            _data.UpdateNinjaDojo(id);
            return RedirectToAction("ShowDojo", back);
        }
    }
}