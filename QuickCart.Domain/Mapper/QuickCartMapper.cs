
using AutoMapper;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Models;

namespace QuickCart.Domain.Mapper
{
    public class QuickCartMapper :Profile
    {
        public QuickCartMapper()
        {

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
