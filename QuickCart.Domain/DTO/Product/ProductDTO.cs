

namespace QuickCart.Domain.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
