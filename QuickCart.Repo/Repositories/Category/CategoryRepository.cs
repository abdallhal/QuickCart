
using QuickCart.DataAccess.Models;
using QuickCart.Domain.Models;

namespace QuickCart.Repo
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository    
    {
        public CategoryRepository(QuickCartDbContext context):base(context) { }
       
    }
}
