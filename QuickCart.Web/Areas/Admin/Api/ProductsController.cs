using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuickCart.Domain.DTO;
using QuickCart.Services;

namespace QuickCart.Web.Areas.Admin.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
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
                var requestDTO = new GetAllBaseRequestDTO
                {
                    Pagination = queryValues.Pagination,
                    Search = queryValues.Search,
                    Order = queryValues.Order,
                };
                var result =  _service.GetAll(requestDTO);
                var TotalRecords = result.TotalRecords;
                var jsonData = new { recordsFiltered = TotalRecords, TotalRecords, data = result.Data };
                return Ok(jsonData);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
