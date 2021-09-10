using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetWebApiService.Core.QueryableExtensions
{
    /// <summary>
    /// Создание интерфейса объекта с методом Include
    /// </summary>
    public interface IIncluder
    {
        IIncludableQueryable<T, TProperty> Include<T, TProperty>(
            IQueryable<T> source,
            Expression<Func<T, TProperty>> path
        ) where T : class;
    }
}
