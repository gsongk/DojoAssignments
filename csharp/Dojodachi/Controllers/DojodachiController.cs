using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Dojodachi;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<Dachi>("Dojodachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("Dojodachi", new Dachi());
            }

            ViewBag.Dojodachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dojodachi");
            ViewBag.Message = "You have a new Dojodachi!";
            ViewBag.GameStatus = "running";
            ViewBag.Reaction = "";
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string action)
        {
            Dachi EditDachi = HttpContext.Session.GetObjectFromJson<Dachi>("Dojodachi");
            Random rand = new Random();
            ViewBag.GameStatus = "running";
            switch(action)
            {
                case "feed":
                    if(EditDachi.Meals > 0)
                    {
                        EditDachi.Meals -= 1;
                        if(rand.Next(0,4)>0)
                        {
                            EditDachi.Fullness += rand.Next(5,11);
                            ViewBag.Reaction = "(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧  Happy!!! (ﾉ◕ヮ◕)ﾉ*:･ﾟ✧ ";
                            ViewBag.message = "(づ｡◕‿‿◕｡)づ Your pet enjoyed it's meal! (づ｡◕‿‿◕｡)づ";
                        }
                        else
                        {
                            ViewBag.Reaction = "(◣_◢) Angry!!! (◣_◢)";
                            ViewBag.message = "ᕙ(⇀‸↼‶)ᕗ Your pet hated the food!!! ᕙ(⇀‸↼‶)ᕗ";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = "ಠ益ಠ Angry!!! ಠ益ಠ";
                        ViewBag.message = "(┛◉Д◉)┛彡┻━┻  You do not have any food for your pet! (┛◉Д◉)┛彡┻━┻";
                    }
                    break;
                case "play":
                    if(EditDachi.Energy > 0)
                    {
                        EditDachi.Energy -=5;
                        if(rand.Next(0,4)>0)
                        {
                            EditDachi.Happiness += rand.Next(5,11);
                            ViewBag.Reaction = "〜(^∇^〜）Excited!!!（〜^∇^)〜";
                            ViewBag.message ="(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧ Your pet had fun playing! (ﾉ◕ヮ◕)ﾉ*:･ﾟ✧";
                        }
                        else
                        {
                            ViewBag.Reaction = "(⊙︿⊙✿) Sad!!! (⊙︿⊙✿)";
                            ViewBag.message = "(￣。￣)～ｚｚｚ  Your pet did not want to play!!! (￣。￣)～ｚｚｚ ";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = "{•̃̾_•̃̾} Tired!!! {•̃̾_•̃̾}";
                        ViewBag.message = "⊙▃⊙ Not enough Energy!!! ⊙▃⊙";
                    }
                    break;
                case "work":
                    if(EditDachi.Energy > 4)
                    {
                        EditDachi.Energy -= 5;
                        EditDachi.Meals += rand.Next(1,4);
                        ViewBag.Reaction = "(◕ω◕✿) Happy!!! (◕ω◕✿)";
                        ViewBag.message = "∩(︶▽︶)∩ You worked hard!!! ∩(︶▽︶)∩";
                    }
                    else
                    {
                        ViewBag.Reaction = "{•̃̾_•̃̾} Tired!!! {•̃̾_•̃̾}";
                        ViewBag.message = "⊙▃⊙ Not enough Energy!!! ⊙▃⊙";
                    }
                    break;
                case "sleep":
                    EditDachi.Energy += 15;
                    EditDachi.Fullness -= 5;
                    EditDachi.Happiness -= 5;
                    ViewBag.Reaction = "(◡‿◡✿) Sleeping!!! (◡‿◡✿)";
                    ViewBag.Message = "｡◕‿◕｡ Your Pet slept well!!! ｡◕‿◕｡";
                    break;

                default:
                    ViewBag.Reaction = "ლ(́◉◞౪◟◉‵ლ) Seriously??? ლ(́◉◞౪◟◉‵ლ) ";
                    ViewBag.message = "(×̯×) Glitch!!! (×̯×)";
                    break;
            }

            if(EditDachi.Fullness <1 || EditDachi.Happiness<1)
            {
                ViewBag.Reaction= "٩(͡๏̮͡๏)۶";
                ViewBag.message = "(×̯×) Your pet died!!! (×̯×) ";
                ViewBag.GameStatus = "Over!!!";
            }
            else if (EditDachi.Fullness >99 && EditDachi.Happiness > 99)
            {
                ViewBag.Reaction = "⊙▃⊙";
                ViewBag.message = "★~(◠﹏⊙✿) You Won!!! ★~(◠﹏⊙✿)";
                ViewBag.GameStatus = "Over!!!";
                }
            HttpContext.Session.SetObjectAsJson("Dojodachi", EditDachi);
            ViewBag.Dojodachi = EditDachi;
            return View("Index");
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
    // public static class JsonExtension
    // {
    //     public static void SetObjectAsJson(this ISession session, string key, object value)
    //     {
    //         session.SetString(key, JsonConvert.SerializeObject(value));
    //     }
    //     public static T GetObjectFromJson<T>(this ISession session, string key)
    //     {
    //         var value = session.GetString(key);
    //         return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    //     }
    
    // }
}
