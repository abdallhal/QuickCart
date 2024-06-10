

using AutoMapper;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Models;
using QuickCart.Repo;

namespace QuickCart.Services
{
    public class SubCategoryService : ISubCategoryService
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public ServiceResponse<IEnumerable<SubCategoryDTO>> GetAll()
        {
            var list = _unitOfWork.SubCategory.GetAll();
            var result = _mapper.Map<IEnumerable<SubCategoryDTO>>(list);
            return ServiceResponse<IEnumerable<SubCategoryDTO>>.DeliverData(result);
        }

        public ServiceResponse<IEnumerable<CategoryDTO>> GetAllCategory()
        {
            var list = _unitOfWork.Category.GetAll();
            var result = _mapper.Map<IEnumerable<CategoryDTO>>(list);
            return ServiceResponse<IEnumerable<CategoryDTO>>.DeliverData(result);
        }
        public ServiceResponse<SubCategoryDTO> FirstOrDefault(int id)
        {

            var subCategory = _unitOfWork.SubCategory.FirstOrDefault(o => o.Id == id);

            if (subCategory == null)
            {
                return ServiceResponse<SubCategoryDTO>.ReportError("Invalid category");
            }
            var data = _mapper.Map<SubCategoryDTO>(subCategory);
            return ServiceResponse<SubCategoryDTO>.DeliverData(data);
        }
        public ServiceResponse<CreateSubCategoryDTO> Create(CreateSubCategoryDTO createSubCategoryDTO)
        {

            if (createSubCategoryDTO == null)
            {
                return ServiceResponse<CreateSubCategoryDTO>.ReportError("category is null");
            }
            var subCategory = _mapper.Map<SubCategory>(createSubCategoryDTO);
            _unitOfWork.SubCategory.Add(subCategory);
            _unitOfWork.Complete();
            return ServiceResponse<CreateSubCategoryDTO>.DeliverData(createSubCategoryDTO);

        }

        public ServiceResponse<SubCategoryDTO> Update(SubCategoryDTO categoryDTO)
        {

            var subCategory = _unitOfWork.SubCategory.FirstOrDefault(c => c.Id == categoryDTO.Id);

            if (subCategory == null)
            {
                return ServiceResponse<SubCategoryDTO>.ReportError("category is null");
            }

            _mapper.Map(categoryDTO, subCategory);

            _unitOfWork.SubCategory.Update(subCategory);
            _unitOfWork.Complete();
            return ServiceResponse<SubCategoryDTO>.DeliverData(categoryDTO);

        }


        public ServiceResponse<bool> Delete(int id)
        {

            var subCategory = _unitOfWork.SubCategory.FirstOrDefault(c => c.Id == id);

            if (subCategory == null)
            {
                return ServiceResponse<bool>.ReportError("category is null");
            }
            _unitOfWork.SubCategory.Remove(subCategory);
            _unitOfWork.Complete();
            return ServiceResponse<bool>.DeliverData(true);

        }
    }
}
