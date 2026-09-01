using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username or Email is required.")]
        [Display(Name = "Username or Email")]
        public required string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
