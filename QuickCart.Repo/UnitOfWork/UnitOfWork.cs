
using QuickCart.DataAccess.Models;
using QuickCart.Repo.Repositories;

namespace QuickCart.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuickCartDbContext _context;
     

        public ICategoryRepository Category { get; private set; }

        public ISubCategoryRepository SubCategory { get; private set; }

        public UnitOfWork(QuickCartDbContext context, ICategoryRepository category, ISubCategoryRepository subCategory) {


            _context = context;
            Category = category;
            SubCategory = subCategory;

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
