

using System.Linq.Expressions;

namespace QuickCart.Repo
{
    public interface IBaseRepository<T> where T : class 
    {

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[]? includes);
        T FirstOrDefault(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[]? includes); 

        void Add(T entity); 
        void  Remove(T entity); 
        void RemoveRange(IEnumerable<T> entities);  
        void Update(T entity);  
    }
 
}
