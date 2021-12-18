using LinkConverter.Domain.DBEntity.Base;
using LinkConverter.Domain.Repository.Base;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LinkConverter.Repository.Postgresql.Repositories.Base
{
    public abstract class RepositoryBase<T, Key> : IRepository<T, Key> where T : IDBEntity<Key> where Key : struct
    {
        public Key Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(Key id)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
