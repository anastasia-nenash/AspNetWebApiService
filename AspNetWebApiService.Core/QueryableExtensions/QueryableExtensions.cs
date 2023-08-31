using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AspNetWebApiService.Core.QueryableExtensions
{
    /// <summary>
    /// Вызов метода Include
    /// </summary>
    public static class QueryableExtensions
    {
        public static IIncluder Includer = null;
        public static IIncludableQueryable<T, TProperty> Include<T, TProperty>(
            this IQueryable<T> source,
            Expression<Func<T, TProperty>> path
        )
            where T : class
        {
            return Includer.Include(source, path);
        }
    }
}
