using System;
using System.Text.Json.Serialization;

namespace Zapas.Data.DTO
{
    public class BaseApiResult<T,D>
    {
        public IEnumerable<D>? Data { get; set; }
        [JsonIgnore]
        public IQueryable<T>? Query { get; set; }
        [JsonIgnore]
        public IEnumerable<string>? ExtraFields { get; set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return ((PageIndex + 1) < TotalPages);
            }
        }

        public BaseApiResult() { }

        public BaseApiResult(
            IEnumerable<D>? data,
            int count,
            int pageIndex,
            int pageSize,
            string? sortColumn,
            string? sortOrder)
        {
            Data = data;
            TotalCount = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize!);
            SortColumn = sortColumn;
            SortOrder = sortOrder;
        }
    }
}

