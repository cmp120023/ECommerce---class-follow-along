using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    /// <summary>
    /// Represents a temporary data transfer object blueprint used exclusively for managing account login submissions.
    /// Decorates structural request attributes to verify credentials are provided before querying data access layers.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the identity input credential string supplied by the user.
        /// Can accommodate either a validated account profile handle name or a primary email entry block.
        /// </summary>
        [Required(ErrorMessage = "Username or Email is required.")]
        [Display(Name = "Username or Email")]
        public required string UsernameOrEmail { get; set; }

        /// <summary>
        /// Gets or sets the confidential account access verification key submitted alongside the identity string.
        /// Enforced as a required field string and decorated with specific metadata to hide letters on-screen with dots.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
