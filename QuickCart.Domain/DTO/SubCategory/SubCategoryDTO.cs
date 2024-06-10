
namespace QuickCart.Domain.DTO.SubCategory
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
