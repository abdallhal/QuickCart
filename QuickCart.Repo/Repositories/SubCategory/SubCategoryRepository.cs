

using QuickCart.DataAccess.Models;
using QuickCart.Domain.Models;

namespace QuickCart.Repo.Repositories
{
    public class SubCategoryRepository:BaseRepository<SubCategory>, ISubCategoryRepository 
    {
        public SubCategoryRepository(QuickCartDbContext context) : base(context) { }
       
    }
}
