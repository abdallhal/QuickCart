

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace QuickCart.Domain.DTO
{
    public class ProductFormDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal NewPrice { get; set; }

        public List<IFormFile>? Images { get; set; }

        public List<string>? FilesName { get; set; }

        
        public string? FilesNameToRemove { get; set; }
    }
}
