using Microsoft.EntityFrameworkCore;
using QuickCart.Domain.Models;

namespace QuickCart.DataAccess.Models
{
    public class QuickCartDbContext:DbContext
    {

        public QuickCartDbContext(DbContextOptions<QuickCartDbContext> dbContextOptions):base(dbContextOptions) { 
        
        } 
      

        public DbSet<Category>  Categories { get; set; }    

        //public DbSet<SubCategory> SubCategories { get; set; }
        //public DbSet<Product> Products { get; set; }  
    }
}
