

namespace QuickCart.Repo
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get; }

        int Complete();
    }
}
