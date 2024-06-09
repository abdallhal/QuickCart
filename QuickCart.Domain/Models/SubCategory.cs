
namespace QuickCart.Domain.Models
{
    public class SubCategory :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();    
    }
}
