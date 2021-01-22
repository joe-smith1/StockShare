using System.ComponentModel.DataAnnotations;

namespace SPA.Models.Dtos
{
    /// <summary>
    /// Dto for the properties sent up in a user login request.
    /// </summary>
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}