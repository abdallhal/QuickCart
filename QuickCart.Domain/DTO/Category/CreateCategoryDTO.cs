

using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace QuickCart.Domain.DTO
{

    
   
    public class CreateCategoryDTO
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
