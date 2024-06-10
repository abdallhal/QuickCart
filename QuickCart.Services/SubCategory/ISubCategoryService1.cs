using QuickCart.Domain.DTO;

namespace QuickCart.Services
{
    public interface ISubCategoryService1
    {
        ServiceResponse<CreateSubCategoryDTO> Create(CreateSubCategoryDTO createSubCategoryDTO);
        ServiceResponse<bool> Delete(int id);
        ServiceResponse<SubCategoryDTO> FirstOrDefault(int id);
        ServiceResponse<IEnumerable<SubCategoryDTO>> GetAll();
        ServiceResponse<SubCategoryDTO> Update(SubCategoryDTO categoryDTO);
    }
}