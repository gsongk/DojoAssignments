using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Secrets.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        
        [Display(Name = "First Name")]
        [MinLength(2)]
        [Required]
        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2)]
        public string last_name { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string email { get; set; }

        [Display(Name = "Password")]
        [MinLength(8, ErrorMessage = "Password must be 8 or more characters")]
        [DataType(DataType.Password)]

        [Required]
        public string password { get; set; }
    }
    public class NewUser : User
    {
        [Display(Name = "Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords fields do not match")]
        public string confirm { get; set; }
    }
    public class LoginUser
    {
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string logEmail { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]

        public string logPassword { get; set; }
    }
}