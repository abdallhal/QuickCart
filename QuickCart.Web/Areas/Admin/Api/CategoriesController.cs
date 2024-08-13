using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Enums;
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


        [HttpPost("GetAll")]
        public IActionResult GetAll(DataTablesRequest dataTablesRequest)
        {
            try
            {
             
                var requestDTO = new GetAllSubCategoryRequestDTO
                {
                    Pagination = new Pagination
                    {
                        Skip = dataTablesRequest.Start,
                        PageSize = dataTablesRequest.Length
                    },
                    Search = new Search
                    {
                        SearchValue = dataTablesRequest.Search.Value
                    },
                    Order = new OrderColumn
                    {
                        ColumnName = dataTablesRequest.Columns[dataTablesRequest.Order[0].Column].Data,
                        Direction = dataTablesRequest.Order[0].Dir.Equals("asc", StringComparison.OrdinalIgnoreCase) ? SortDirectionEnum.Ascending : SortDirectionEnum.Descending
                    }
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
