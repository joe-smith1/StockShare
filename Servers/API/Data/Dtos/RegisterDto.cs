using System;
using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    /// <summary>
    /// Dto for receiving the data from the post request for the user registration,
    /// Some validation is applied to required properties and their data types.
    /// </summary>
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Optional properties.
        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public bool PrivateAccount { get; set; }
    }
}