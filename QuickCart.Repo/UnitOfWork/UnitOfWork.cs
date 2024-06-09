
using QuickCart.DataAccess.Models;

namespace QuickCart.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuickCartDbContext _context;
     

        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(QuickCartDbContext context, ICategoryRepository category)
        {
            
            _context = context;
            Category = category;
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
