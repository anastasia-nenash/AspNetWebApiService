using AspNetWebApiService.Core.QueryableExtensions;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace AspNetWebApiService.Tests.CreationDataContextMoq
{
    /// <summary>
    /// Метод Include для тестов
    /// </summary>
    public class IncluderForTests : IIncluder
    {
        public IIncludableQueryable<T, TProperty> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
        {
            return new CustomIncludableQueryObject<T, TProperty>(source);
        }
    }
}
