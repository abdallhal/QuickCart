

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
        ServiceResponse<SubCategoryDTO> Update(SubCategoryDTO categoryDTO);
    }
}
