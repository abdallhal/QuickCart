using QuickCart.Domain.Enums;


namespace QuickCart.Domain.DTO
{
    public class SortData
    {
        public string ColumnName { get; set; }
        public SortDirectionEnum Direction { get; set; }
    }
}
