

using QuickCart.Repo.Repositories;

namespace QuickCart.Repo
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }

        int Complete();
    }
}
