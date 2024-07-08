
using Microsoft.AspNetCore.Mvc;
using QuickCart.Services;

namespace QuickCart.Web.Areas.Admin.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _service;
        public SubCategoriesController(ISubCategoryService service)
        {
            _service = service; 
            
        }


        [HttpGet("GetSubCategories/{categoryId}")]
        public async Task<IActionResult> GetSubCategories(int categoryId)
        {

            var response = await _service.GetAllSelectListItemAsync(categoryId);

            return Ok(response);

        }
    }
}
