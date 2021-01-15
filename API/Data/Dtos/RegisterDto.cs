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
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Optional properties.
        [Phone]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public bool PrivateAccount { get; set; }
    }
}