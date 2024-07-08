

using QuickCart.Domain.DTO;

namespace QuickCart.Services
{
    public interface IProductService
    {
        ServiceResponse<ProductFormDTO> Create(ProductFormDTO createSubCategoryDTO);
        ServiceResponse<bool> Delete(int id);
        ServiceResponse<ProductFormDTO> FirstOrDefault(int id);

     ServiceResponse<IEnumerable<ProductDTO>> GetAll(GetAllBaseRequestDTO requestDTO);
        ServiceResponse<ProductFormDTO> Update(ProductFormDTO productDTO);
    }
}
