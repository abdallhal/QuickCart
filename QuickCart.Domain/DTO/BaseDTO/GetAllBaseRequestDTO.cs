

namespace QuickCart.Domain.DTO
{
    public class GetAllBaseRequestDTO
    {
        public Pagination Pagination { get; set; }
        public OrderColumn Order { get; set; }
        public Search Search { get; set; }
    }
}
