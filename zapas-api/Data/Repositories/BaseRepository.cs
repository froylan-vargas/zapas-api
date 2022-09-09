using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Zapas.Data.DTO;
using Zapas.Data.Repositories;
using System.Linq.Dynamic.Core;
using System.Linq;
using Zapas.Data.DTO.Race;
using Zapas.Data.Models;
using System.Reflection;
using Microsoft.Extensions.Options;
using Zapas.Data.QueryFilters;
using Zapas.Data.QueryOptions;
using Zapas.Helpers;

namespace Zapas.Data
{
    public class BaseRepository<T,M> where T: class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async virtual Task<BaseApiResult<T,M>>? Get(
            BaseQueryOptions options,
            IEnumerable<Expression<Func<T,bool>>> filters,
            ExtraQueryFields<T>? getExtraFields = null
            )
        {
            var sortColumn = options.SortColumn;
            var sortOrder = options.SortOrder;
            var pageIndex = options.PageIndex;
            var pageSize = options.PageSize;

            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            var count = await query.CountAsync();

            if (count == 0)
            {
                return new BaseApiResult<T,M>();
            }

            IEnumerable<string> extraFields = await getExtraFields!(query,count);

            if (!string.IsNullOrEmpty(options.SortColumn)
            && IsValidProperty(options.SortColumn))
            {
                options.SortOrder = !string.IsNullOrEmpty(options.SortOrder)
                    && options.SortOrder.ToUpper() == "ASC"
                    ? "ASC"
                    : "DESC";
                query = query.OrderBy(
                string.Format(
                "{0} {1}",
                        options.SortColumn,
                        options.SortOrder)
                    );
            }

                query = query
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize);
            

            var result = new BaseApiResult<T,M>(null,count,
                pageIndex,
                pageSize,
                sortColumn,
                sortOrder);

            result.Query = query;
            result.ExtraFields = extraFields;

            return result;
        }

        public virtual async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        private static bool IsValidProperty(
            string propertyName,
            bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(T).GetProperty(
                propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);
            if (prop == null && throwExceptionIfNotFound)
                throw new NotSupportedException($"ERROR: Property '{propertyName}' does not exist.");
            return prop != null;
        }

        /*public Task<T> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }*/
        }
    }
