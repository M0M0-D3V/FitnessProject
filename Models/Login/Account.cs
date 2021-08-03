using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string LoginEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }
    }

    public class RegisterViewModel
    {

        [Required]
        [MinLength(2, ErrorMessage = "{0} must be 2 characters or longer!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be 2 characters or longer!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The {0} must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }

}