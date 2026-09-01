using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class RegistrationViewModel
    {
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username must be alphanumeric.")]
        [StringLength(25)]
        public required string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public required string Email { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "Your password must be between 6 and 50 characters long.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
    }
}
