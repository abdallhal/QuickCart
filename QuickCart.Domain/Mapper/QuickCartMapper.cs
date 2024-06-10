
using AutoMapper;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Models;

namespace QuickCart.Domain.Mapper
{
    public class QuickCartMapper :Profile
    {
        public QuickCartMapper()
        {

            // category
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, SubCategoryDTO>().ReverseMap();

            // sub category
            CreateMap<SubCategory, CreateSubCategoryDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
        }
    }
}
