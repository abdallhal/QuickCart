

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCart.Domain.Models
{
    public class Product :BaseEntity
    {
        [Required]
        public  string Name { get; set; }   

     
        public string Description { get; set; }
        [Required]  
        public int SubCategoryId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal NewPrice { get; set; }

        [ForeignKey(nameof(SubCategoryId))]    
        public virtual SubCategory SubCategory { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }    
        public virtual ICollection<ProductImage> ProductImages { get; set; } =new HashSet<ProductImage>();
    }
}
