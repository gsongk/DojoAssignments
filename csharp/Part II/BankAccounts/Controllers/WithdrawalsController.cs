using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class WithdrawalsController : Controller
    {
        private BankAccountContext _context;
        public WithdrawalsController(BankAccountContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("account/{id}")]
        public IActionResult DisplayAll(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (id != UserId)
            {
                return Redirect($"/account/{UserId}");
            }
            User user = _context.Users
                            .Include(u => u.Withdrawals)
                            .Where(u => u.Id == id).SingleOrDefault();
            if (user.Withdrawals != null)
            {
                user.Withdrawals = user.Withdrawals.OrderByDescending(wd => wd.CreatedAt).ToList();
            }
            ViewBag.UserInfo = user;
            return View();
        }

        [HttpPost]
        [Route("transaction")]
        public IActionResult Transaction(float Amount)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            User user = _context.Users.Where(u => u.Id == UserId).SingleOrDefault();
            if (Amount < 0 && ((Amount * -1) > user.Balance))
            {
                TempData["Error"] = "Insufficient Funds";
            }
            else
            {
                Withdrawal wd = new Withdrawal
                {
                    Amount = Amount,
                    User = user,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                user.Balance += Amount; // still a withdrawal because Amount is negative
                _context.Withdrawals.Add(wd);
                _context.SaveChanges();
            }
            return Redirect($"/account/{UserId}");
        }
    }
}