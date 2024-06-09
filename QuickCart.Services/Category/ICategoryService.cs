
using QuickCart.Domain.DTO;

namespace QuickCart.Services
{
    public interface ICategoryService
    {
        ServiceResponse<CreateCategoryDTO> Create(CreateCategoryDTO categoryDTO);
        ServiceResponse<CategoryDTO> FirstOrDefault(int id);
        ServiceResponse<IEnumerable<CategoryDTO>> GetAll();
    }
}
