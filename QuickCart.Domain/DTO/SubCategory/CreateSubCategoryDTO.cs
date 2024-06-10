
using System.ComponentModel.DataAnnotations;

namespace QuickCart.Domain.DTO
{
    public class CreateSubCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
