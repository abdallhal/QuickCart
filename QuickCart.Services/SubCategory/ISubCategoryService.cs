

using Microsoft.AspNetCore.Mvc.Rendering;
using QuickCart.Domain.DTO;

namespace QuickCart.Services
{
    public interface ISubCategoryService
    {
        ServiceResponse<CreateSubCategoryDTO> Create(CreateSubCategoryDTO createSubCategoryDTO);
        ServiceResponse<bool> Delete(int id);
        ServiceResponse<SubCategoryDTO> FirstOrDefault(int id);
        ServiceResponse<IEnumerable<SubCategoryDTO>> GetAll();
        ServiceResponse<IEnumerable<CategoryDTO>> GetAllCategory();
        Task<ServiceResponse<IEnumerable<SelectListItem>>> GetAllSelectListItemAsync(int categoryId);
        ServiceResponse<SubCategoryDTO> Update(SubCategoryDTO categoryDTO);
    }
}
