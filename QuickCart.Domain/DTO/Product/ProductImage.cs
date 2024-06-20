using Microsoft.AspNetCore.Http;


namespace QuickCart.Domain.DTO
{
    public class ProductImageDTO
    {
        public bool IsMain { get; set; }
        public IFormFile? Image { get; set; }
    }
}
