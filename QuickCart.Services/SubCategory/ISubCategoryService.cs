

using Microsoft.AspNetCore.Mvc.Rendering;
using QuickCart.Domain.DTO;

namespace QuickCart.Services
{
    public interface ISubCategoryService
    {
        ServiceResponse<SubCategoryFormDTO> Create(SubCategoryFormDTO createSubCategoryDTO);
        ServiceResponse<bool> Delete(int id);
        ServiceResponse<SubCategoryFormDTO> FirstOrDefault(int id);
        ServiceResponse<IEnumerable<SubCategoryDTO>> GetAll();
        ServiceResponse<IEnumerable<CategoryDTO>> GetAllCategory();
        Task<ServiceResponse<IEnumerable<SelectListItem>>> GetAllSelectListItemAsync(int categoryId);
        ServiceResponse<SubCategoryFormDTO> Update(SubCategoryFormDTO categoryDTO);
    }
}
