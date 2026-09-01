using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username must be alphanumeric.")]
        [StringLength(25)]
        public required string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public required string Email { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "Your password must be between 6 and 50 characters long.")]
        public required string Password { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
