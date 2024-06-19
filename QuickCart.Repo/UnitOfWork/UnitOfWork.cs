
using QuickCart.DataAccess.Models;
using QuickCart.Repo.Repositories;

namespace QuickCart.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuickCartDbContext _context;
     

        public ICategoryRepository Category { get; private set; }

        public ISubCategoryRepository SubCategory { get; private set; }

        public IProductRepository Product { get; private set; }

        public UnitOfWork(QuickCartDbContext context, 
            ICategoryRepository category,
            ISubCategoryRepository subCategory,
            IProductRepository product)
        {


            _context = context;
            Category = category;
            SubCategory = subCategory;
            Product = product;
        }


        public int Complete()
        {
         return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();     
        }
    }
}
