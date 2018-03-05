using System;
using System.Collections.Generic;
using BankAccounts.Models;

namespace BankAccounts
{
    public class User
    {
        public User()
        {
            Withdrawals = new List<Withdrawal>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public float Balance { get; set; }
        public List<Withdrawal> Withdrawals { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}