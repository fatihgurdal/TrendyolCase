using LinkConverter.Domain.DBEntity.Base;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LinkConverter.Domain.Repository.Base
{
    public interface IRepository<T, Key> where T : IDBEntity<Key> where Key : struct
    {
        Key Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Find(Key id);
        T FirstOrDefault(Expression<Func<T, bool>> where);
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
    }
}
