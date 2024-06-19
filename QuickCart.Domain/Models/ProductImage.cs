
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCart.Domain.Models
{
    public class ProductImage :BaseEntity
    {

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public bool IsActive { get; set; }  
    }
}
