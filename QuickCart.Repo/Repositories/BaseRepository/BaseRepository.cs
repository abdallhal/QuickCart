
using Microsoft.EntityFrameworkCore;
using QuickCart.DataAccess.Models;
using System.Linq.Expressions;

namespace QuickCart.Repo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly QuickCartDbContext _dbContext;
        private readonly  DbSet<T> _dbSet;   
        public BaseRepository(QuickCartDbContext dbContext)
        {
            _dbContext = dbContext; 

            _dbSet = _dbContext.Set<T>();    
                    
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity); 
        }

        public T FirstOrDefault(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> query = _dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null && includes.Any())
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault();
        }


        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression=null, params Expression<Func<T, object>>[]? includes )
        {
            IQueryable<T> query = _dbSet;
            if (expression != null)
            {

                query = query.Where(expression);
            }
            if (includes!=null&&includes.Any()) {


                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }

}
