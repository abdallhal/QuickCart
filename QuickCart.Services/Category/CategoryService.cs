
using AutoMapper;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Models;
using QuickCart.Repo;

namespace QuickCart.Services
{
    public class CategoryService : ICategoryService 
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork  unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }



        public ServiceResponse<IEnumerable<CategoryDTO>> GetAll()
        {
            var list = _unitOfWork.Category.GetAll();
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(list);
            return ServiceResponse<IEnumerable<CategoryDTO>>.DeliverData(categoryDTOs);
        }
        public ServiceResponse<CategoryDTO> FirstOrDefault(int id) { 
        
            var obj=_unitOfWork.Category.FirstOrDefault(o=>o.Id == id);

            if (obj == null)
            {
                return ServiceResponse<CategoryDTO>.ReportError("Invalid category");
            }
            var data = _mapper.Map<CategoryDTO>(obj); 
            return ServiceResponse<CategoryDTO>.DeliverData(data);
        }
        public ServiceResponse<CreateCategoryDTO> Create(CreateCategoryDTO categoryDTO)
        {

            if (categoryDTO == null)
            {
                return ServiceResponse<CreateCategoryDTO>.ReportError("category is null");
            }
            var category = _mapper.Map<Category>(categoryDTO);
            _unitOfWork.Category.Add(category);
            _unitOfWork.Complete();
            return ServiceResponse<CreateCategoryDTO>.DeliverData(categoryDTO);

        }

        public ServiceResponse<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
        
            var category = _unitOfWork.Category.FirstOrDefault(c => c.Id == categoryDTO.Id);

            if (category==null)
            {
                return ServiceResponse<CategoryDTO>.ReportError("category is null");
            }

            _mapper.Map(categoryDTO,category);

            _unitOfWork.Category.Update(category);
            _unitOfWork.Complete();
            return ServiceResponse<CategoryDTO>.DeliverData(categoryDTO);

        }


        public ServiceResponse<bool> Delete(int  id)
        {

            var category = _unitOfWork.Category.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return ServiceResponse<bool>.ReportError("category is null");
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Complete();
            return ServiceResponse<bool>.DeliverData(true);

        }
    }
}
