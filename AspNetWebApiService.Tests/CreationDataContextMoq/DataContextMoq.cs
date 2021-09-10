using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace AspNetWebApiService.Tests.CreationDataContextMoq
{
    /// <summary>
    /// Moq-объект контекста
    /// </summary>
    public static class DataContextMoq
    {
        /// <summary>
        /// Иницилизация DbSet
        /// </summary>
        /// <typeparam name="T">Любой тип объектов</typeparam>
        /// <param name="sourceList">Лист данных для заполнения DbSet</param>
        /// <returns>Mock DbSet</returns>
        public static Mock<DbSet<T>> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            dbSet.Setup(d => d.Remove(It.IsAny<T>())).Callback<T>((s) => sourceList.Remove(s));
            return dbSet;
        }
    }
}
