
using System.ComponentModel.DataAnnotations;

namespace QuickCart.Domain.Models
{
    public class Category  : BaseEntity
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; } 
       // public virtual ICollection<SubCategory> Subcategories { get; set; }= new HashSet<SubCategory>();    


    }
}
