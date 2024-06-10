using System.ComponentModel.DataAnnotations;

using System.Web.Mvc; // Add a semicolon at the end of this line

namespace QuickCart.Domain.DTO
{
    public class CreateSubCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
