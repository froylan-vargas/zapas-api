using System;
using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using Zapas.Data.Models;

namespace Zapas.Data.Repositories
{
	public class BaseQueryOptions
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
    }
}

