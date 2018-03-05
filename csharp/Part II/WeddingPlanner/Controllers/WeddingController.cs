using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private Context _context;
        private User ActiveUser
        {
            get { return _context.users.Where(u => u.user_id == HttpContext.Session.GetInt32("id")).FirstOrDefault(); }
        }
        public WeddingController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (ActiveUser == null)
                return RedirectToAction("Index", "Home");
            Dashboard dashData = new Dashboard
            {
                Weddings = _context.weddings.Include(w => w.Guests).ToList(),
                User = ActiveUser
            };
            return View(dashData);
        }
        public IActionResult Create()
        {
            if (ActiveUser == null)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ViewWedding newWedding)
        {
            if (ActiveUser == null)
                return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                Wedding wedding = new Wedding
                {
                    bride_name = newWedding.WedderOne,
                    groom_name = newWedding.WedderTwo,
                    date = newWedding.Date,
                    address = newWedding.Address,
                    user_id = ActiveUser.user_id
                };
                _context.weddings.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newWedding);
        }
        public IActionResult Rsvp(int id)
        {
            if (ActiveUser == null)
                return RedirectToAction("Index", "Home");
            RSVP rsvp = new RSVP
            {
                user_id = ActiveUser.user_id,
                wedding_id = id
            };
            _context.rsvps.Add(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UnRsvp(int id)
        {
            if (ActiveUser == null)
                return RedirectToAction("Index", "Home");
            RSVP toDelete = _context.rsvps.Where(r => r.wedding_id == id)
                                          .Where(r => r.user_id == ActiveUser.user_id)
                                          .SingleOrDefault();
            _context.rsvps.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Show(int id)
        {
            if (HttpContext.Session.GetInt32("id") == null)
                return RedirectToAction("Index");
            return View(_context.weddings.Include(w => w.Guests).ThenInclude(g => g.Guest).Where(w => w.wedding_id == id).SingleOrDefault());
        }

    }
}