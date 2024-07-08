using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickCart.Services;

namespace QuickCart.Web.Areas.Admin.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {

            try
            {
                var response = await _service.GetAllSelectListItemAsync();

                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
   

        }
    }
}
