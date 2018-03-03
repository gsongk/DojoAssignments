using System.ComponentModel.DataAnnotations;
namespace LoginRegistration.Models
{
    public class RegisterUser
    {
        [Required]
        [Display(Name="First Name")]
        [MinLength(2)]
        public string FirstName {get;set;}

        [Required]
        [Display(Name="Last Name")]
        [MinLength(2)]
        public string LastName {get;set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Invalid Email")]
        [Display(Name="Email")]
        public string Email {get;set;}

        [Required]
        [Display(Name="Password")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [Required]
        [Display(Name="Confirm")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get;set;}
    }
    public class LoginUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        [EmailAddress(ErrorMessage="Invalid Email")]
        public string LogEmail {get;set;}

        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LogPassword{get;set;}
    }
    public class HomePageUsers
    {
        public RegisterUser Register {get;set;}
        public LoginUser Login {get;set;}
    }
}