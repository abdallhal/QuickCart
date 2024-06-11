

using System.ComponentModel.DataAnnotations;

namespace QuickCart.Domain.Models
{
    public class Product :BaseEntity
    {
        [Required]
        public  string Name { get; set; }   

        public string Description { get; set; }
        [Required]  
        public int SubCategoryId { get; set; }  
        public string  Img { get; set; }
        [Required]
        public decimal Price { get; set; }  
        public virtual SubCategory SubCategory { get; set; }    
    }
}
