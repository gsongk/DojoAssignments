using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class NewUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm { get; set; }
    }

    public class LogUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string LogEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string LogPassword { get; set; }
    }
}