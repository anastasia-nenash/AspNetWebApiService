using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetWebApiService.Core.QueryableExtensions
{
    using EFCore = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

    /// <summary>
    /// Использование метода Include из библиотеки EntityFramework
    /// </summary>
    public class DbIncluder : IIncluder
    {
        public IIncludableQueryable<T, TProperty> Include<T, TProperty>(
            IQueryable<T> source,
            Expression<Func<T, TProperty>> path
        )
            where T : class
        {
            return EFCore.Include(source, path);
        }
    }
}
