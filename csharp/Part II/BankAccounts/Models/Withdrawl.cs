using System;

namespace BankAccounts.Models
{
    public class Withdrawal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}