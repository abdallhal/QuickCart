

using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuickCart.Domain.DTO
{
    public class CreateSubCategoryVM
    {
     public    CreateSubCategoryDTO SubCategoryDTO { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
