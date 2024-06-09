

using System.ComponentModel.DataAnnotations;

namespace QuickCart.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
