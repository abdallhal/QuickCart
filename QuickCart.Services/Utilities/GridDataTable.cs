
using Microsoft.AspNetCore.Http;
using QuickCart.Domain.DTO;
using QuickCart.Domain.Enums;
using QuickCart.Services.Utilities;

namespace QuickCart.Services
{
    public class GridDataTable
    {

        public GetAllBaseRequestDTO GetQueryNameValuePairs(IQueryCollection queryValues)
        {
            int pageSize = 10;
            int skip = 0;

            if (queryValues.TryGetValue("start", out var startValues))
            {
                int.TryParse(startValues.FirstOrDefault(), out skip);
            }

            if (queryValues.TryGetValue("length", out var lengthValues))
            {
                int.TryParse(lengthValues.FirstOrDefault(), out pageSize);
            }

            queryValues.TryGetValue("search.value", out var searchValues);
            var searchValue = searchValues.FirstOrDefault();

            queryValues.TryGetValue("order[0].column", out var sortColumnValues);
            var sortColumn = sortColumnValues.FirstOrDefault();

            var columnName = queryValues.FirstOrDefault(q => q.Key.Equals($"columns[{sortColumn}].data")).Value;

            queryValues.TryGetValue("order[0].dir", out var sortColumnDirectionValues);
            var sortColumnDirection = sortColumnDirectionValues.FirstOrDefault();

            var result = new GetAllBaseRequestDTO()
            {
                Pagination = new Pagination
                {
                    PageSize = pageSize,
                    Skip = skip,
                },
                Order = new OrderColumn
                {
                    ColumnName = columnName,
                    Direction = !string.IsNullOrEmpty(sortColumnDirection) && sortColumnDirection.Equals("asc", StringComparison.OrdinalIgnoreCase)
                        ? SortDirectionEnum.Ascending
                        : SortDirectionEnum.Descending,
                },
                Search = new Search
                {
                    SearchValue = searchValue,
                }
            };

            return result;
        }
        public void GetDataSortedAndPaginated<T>(ref IQueryable<T> dataCollection, GetAllBaseRequestDTO requestDTO, string defaultColumn = "Id") where T : class
        {
            if (dataCollection.Any())
            {
                var sortData = new SortData
                {
                    ColumnName = requestDTO.Order.IsSortingEnabled ? requestDTO.Order.ColumnName : defaultColumn,
                    Direction = requestDTO.Order.IsSortingEnabled ? requestDTO.Order.Direction : SortDirectionEnum.Descending
                };

              var pageList = new PageList<T>(dataCollection);
              pageList.Sort( sortData);
              pageList.ApplyPagination( requestDTO.Pagination.Skip, requestDTO.Pagination.PageSize);

                dataCollection = pageList.DataSource;
            }
        }
    }



}

