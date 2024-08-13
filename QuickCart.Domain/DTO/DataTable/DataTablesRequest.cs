

namespace QuickCart.Domain.DTO
{
    public class DataTablesRequest
    {
        public int Draw { get; set; }
        public DataTablesColumn[] Columns { get; set; }
        public DataTablesOrder[] Order { get; set; }
        public DataTablesSearch Search { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
