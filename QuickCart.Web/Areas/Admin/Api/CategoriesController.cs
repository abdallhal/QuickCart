using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickCart.Domain.DTO;
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


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var queryParameters = HttpContext.Request.Query;
                var queryValues = new GridDataTable().GetQueryNameValuePairs(queryParameters);
                var requestDTO = new GetAllCategoryRequestDTO
                {
                    Pagination = queryValues.Pagination,
                    Search = queryValues.Search,
                    Order = queryValues.Order,
                };
                var result = _service.GetAll(requestDTO);
                var TotalRecords = result.TotalRecords;
                var jsonData = new { recordsFiltered = TotalRecords, TotalRecords, data = result.Data };
                return Ok(jsonData);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
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
