using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    /// <summary>
    /// Represents the core database entity schema blueprint for a persistent user account record.
    /// Maps directly to the matching SQL database server table structure.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Gets or sets the unique identity tracking numeric integer value assigned automatically to every user.
        /// Configured as the explicit Primary Key descriptor parameter for database indexing.
        /// </summary>
        [Key]
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the custom profile display handle selected by the user during the initial signup phase.
        /// Restricted strictly to standard alphanumeric characters with an absolute ceiling of 25 parameters.
        /// </summary>
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username must be alphanumeric.")]
        [StringLength(25)]
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the primary digital messaging communication contact handle mapped to the account profile.
        /// Constrained strictly to standard internet data formatting conventions containing an active domain wrapper segment.
        /// </summary>
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the core secret key verification string used to authenticate identity requests during login transitions.
        /// Restricted to explicit data boundary rules requiring a length parameters value between 6 and 50 elements.
        /// </summary>
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Your password must be between 6 and 50 characters long.")]
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the user's documented date of birth recorded as a precise calendar matrix milestone.
        /// Restricts tracking limits strictly to clean temporal days without calculating or displaying active background clock timestamps.
        /// </summary>
        public DateOnly DateOfBirth { get; set; }
    }
}
