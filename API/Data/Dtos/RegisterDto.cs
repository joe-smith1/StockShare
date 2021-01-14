using System;
using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    public class RegisterDto
    {
        // TODO Document class.
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public bool PrivateAccount { get; set; }
    }
}