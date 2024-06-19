
using QuickCart.DataAccess.Models;
using QuickCart.Domain.Models;

namespace QuickCart.Repo.Repositories
{
    public class ProductRepository :BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(QuickCartDbContext context):base(context)
        {
                
        }
    }
}
