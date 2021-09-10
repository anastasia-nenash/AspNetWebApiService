using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetWebApiService.Tests.CreationDataContextMoq
{
    /// <summary>
    /// Пользовательский объект для замещения метода Include
    /// </summary>
    public class CustomIncludableQueryObject<T, Y> : IIncludableQueryable<T, Y>
    {
        public CustomIncludableQueryObject(IQueryable<T> obj)
        {
            _objectToReturn = obj;
        }

        private IQueryable<T> _objectToReturn;

        public Type ElementType => _objectToReturn.ElementType;

        public Expression Expression => _objectToReturn.Expression;

        public IQueryProvider Provider => _objectToReturn.Provider;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _objectToReturn.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _objectToReturn.GetEnumerator();
        }
    }
}
