

using QuickCart.Domain.DTO;
using QuickCart.Domain.Enums;
using System.Linq.Dynamic.Core;
namespace QuickCart.Services.Utilities
{
    public class PageList<T> where T : class
    {
        public IQueryable<T> DataSource { get; private set; }
        public PageList(IQueryable<T> Data)
        {
            this.DataSource = Data;
        }
        public void Sort(SortData sortData)
        {
            var orderExpression = "Id"; // Default

            if (sortData != null && sortData.ColumnName != null)
            {
                orderExpression = $"{sortData.ColumnName} {(sortData.Direction == SortDirectionEnum.Ascending ? "asc" : "desc")}";
            }

            DataSource = DataSource.OrderBy(orderExpression);

        }

        public void ApplyPagination( int? pageIndex, int? pageSize)
        {

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                DataSource = DataSource.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
            }
            else if (pageSize.HasValue)
            {
                DataSource = DataSource.Skip(0).Take(pageSize.Value); 
            }
            else
            {
                DataSource = DataSource.Skip(pageIndex.GetValueOrDefault(0));
            }

        }


    }
}
