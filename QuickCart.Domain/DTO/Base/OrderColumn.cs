

using QuickCart.Domain.Enums;

namespace QuickCart.Domain.DTO
{
    public class OrderColumn
    {
        public string ColumnName { get; set; }
        public SortDirectionEnum Direction { get; set; }

        public bool IsSortingEnabled => !string.IsNullOrEmpty(ColumnName);

        public OrderColumn()
        {
            this.ColumnName = "Id";
            this.Direction = SortDirectionEnum.Descending;
        }
    }
}
