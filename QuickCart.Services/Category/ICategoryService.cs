
using QuickCart.Domain.DTO;

namespace QuickCart.Services
{
    public interface ICategoryService
    {
        ServiceResponse<CreateCategoryDTO> Create(CreateCategoryDTO categoryDTO);
        ServiceResponse<bool> Delete(int id);
        ServiceResponse<CategoryDTO> FirstOrDefault(int id);
        ServiceResponse<IEnumerable<CategoryDTO>> GetAll();
        ServiceResponse<CategoryDTO> Update(CategoryDTO categoryDTO);
    }
}
