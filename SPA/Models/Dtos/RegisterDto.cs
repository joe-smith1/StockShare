using System;
using System.ComponentModel.DataAnnotations;

namespace SPA.Models.Dtos
{
    /// <summary>
    /// Dto for receiving the data from the post request for the user registration,
    /// Some validation is applied to required properties and their data types.
    /// </summary>
    public class RegisterDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long", MinimumLength = 1)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // Optional properties.
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Private account")]
        public bool PrivateAccount { get; set; }
    }
}