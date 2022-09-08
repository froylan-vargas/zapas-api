using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using Zapas.Data.DTO;
using Zapas.Data.Repositories;
using System.Linq.Dynamic.Core;
using System.Drawing.Printing;
using System.Linq;
using Zapas.Data.DTO.Race;
using Zapas.Data.Models;

namespace Zapas.Data
{
    public class BaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async virtual Task<BaseApiResult<T>> Get(
            BaseQueryOptions queryOptions,
            IEnumerable<Expression<Func<Race, bool>>> filters)
        {
            IQueryable<T> query = _dbSet;
            var sortColumn = queryOptions.SortColumn;
            var sortOrder = queryOptions.SortOrder;
            var pageIndex = queryOptions.PageIndex;
            var pageSize = queryOptions.PageSize;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            var count = await query.CountAsync();

            if(count == 0)
            {
                return new BaseApiResult<T>(0, 0, 0, "", "");
            }

            if (!string.IsNullOrEmpty(sortColumn)
                && IsValidProperty(sortColumn))
            {
                sortOrder = !string.IsNullOrEmpty(sortOrder)
                    && sortOrder.ToUpper() == "ASC"
                    ? "ASC"
                    : "DESC";
                query = query.OrderBy(
                    string.Format(
                        "{0} {1}",
                        sortColumn,
                        sortOrder)
                    );
            }

            if(pageIndex!= null && pageSize!=null)
            {
                query = query
                    .Skip(pageIndex.Value * pageSize.Value)
                    .Take(pageSize.Value);
            }

            var result = new BaseApiResult<T>(count,
                pageIndex,
                pageSize,
                sortColumn,
                sortOrder);

            result.Query = query;
            //Hay que investigar como pasar de IDynamycQuery a Queryable. 
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
