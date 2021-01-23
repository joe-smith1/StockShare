using System.ComponentModel.DataAnnotations;

namespace SPA.Models.Dtos
{
    /// <summary>
    /// Dto for the properties sent up in a user login request.
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// The Email of the user to login, using email as its easier to remember than the username
        /// is a required property.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// The Password of the user to login also is required.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// If the user wants to be provided with cookies to remember them on this browser.
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}