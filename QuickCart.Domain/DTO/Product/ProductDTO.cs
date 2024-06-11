

using System.ComponentModel.DataAnnotations;

namespace QuickCart.Domain.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        public string Img { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
