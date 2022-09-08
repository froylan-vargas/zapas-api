using System;
namespace Zapas.Data.DTO
{
    public class BaseApiResult<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public IQueryable? Query { get; set; }
        public int? PageIndex { get; private set; }
        public int? PageSize { get; private set; }
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

        public BaseApiResult(
            int count,
            int? pageIndex,
            int? pageSize,
            string? sortColumn,
            string? sortOrder)
        {
            Data = null;
            Query = null;
            TotalCount = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize!);
            SortColumn = sortColumn;
            SortOrder = sortOrder;
        }
    }
}

