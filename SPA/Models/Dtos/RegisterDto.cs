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
        /// <summary>
        /// The Username of the user to create it must be at least 1 character and at most 50 it is required.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long", MinimumLength = 1)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        /// <summary>
        /// The Password of the user to create it must be at least 6 characters and is required.
        /// </summary>
        [Required]
        [MinLength(6, ErrorMessage = "The {0} must be at least {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Confirm password property is used to Compare with the <see cref="Password"/> property for validation to match.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// The Email of the user to create it is required.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // Optional properties.

        /// <summary>
        /// The Phone number of the user to create it is optional.
        /// </summary>
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The Date of Birth of the user it is optional.
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// If the users account should be private or public public is the default.
        /// </summary>
        [Display(Name = "Private account")]
        public bool PrivateAccount { get; set; }
    }
}