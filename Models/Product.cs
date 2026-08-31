using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Product
    {
        /// <summary>
        /// Product Identifier
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// The user facing title of the product
        /// </summary>
        [Required]
        [StringLength(50,ErrorMessage ="Title can not be more than 50 characters.")]
        public string Title { get; set; }

        /// <summary>
        /// current5 sales price of product
        /// </summary>
        [Range(0,10_000)]
        public decimal Price { get; set; }
    }
}
