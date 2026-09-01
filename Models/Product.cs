using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    /// <summary>
    /// Represents the database entity schema blueprint for a persistent commercial item catalog listing.
    /// Maps directly to the matching SQL database server table structure.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identity tracking numeric integer value assigned automatically to every product.
        /// Configured as the explicit Primary Key descriptor parameter for database indexing.
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the user-facing public text heading display name of the commercial product item.
        /// Enforced as a required field string with a maximum boundary cap parameter of 50 characters.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Title can not be more than 50 characters.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the current monetary market retail sales cost assigned to the catalog product item.
        /// Restricted to explicit data boundary rules tracking between 0.00 and 10,000.00 currency parameters.
        /// </summary>
        [Range(0, 10_000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
