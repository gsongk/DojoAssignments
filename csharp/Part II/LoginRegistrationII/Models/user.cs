using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace LoginRegistrationII.Models
{
    public class user
    {
        [Display(Name = "First Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Name Fields must be 2 or more characters")]
        public string first_name { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Name Fields must be 2 or more characters")]
        public string last_name { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 or more characters")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string confirm { get; set; }
    }
    public class LogUser
    {
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 or more characters")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}