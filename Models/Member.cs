using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [RegularExpression("^[a-zA-Z0-9]+$",
            ErrorMessage = "user must be alphnumeric")]
        [StringLength(25)]
        public required string Username { get; set; }

        public required string Email { get; set; }

        [StringLength(50, MinimumLength = 6, 
            ErrorMessage ="your password must between 6 and 50 characters long")]
        public required string Password { get; set; }

        public DateOnly DateOfBirth { get; set; }

    }
}
