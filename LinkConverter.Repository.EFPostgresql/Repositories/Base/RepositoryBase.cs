using LinkConverter.Domain.DBEntity.Base;
using LinkConverter.Domain.Repository.Base;
using LinkConverter.Repository.EFPostgresql.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinkConverter.Repository.EFPostgresql.Repositories.Base
{
    public abstract class RepositoryBase<T, Key> : IRepository<T, Key> where T : class, IDBEntity<Key> where Key : struct
    {
        protected LinkConverterContext Context { get; private set; }
        private DbSet<T> Table { get; set; }
        internal RepositoryBase(LinkConverterContext dbContext)
        {
            this.Context = dbContext;
            Table = dbContext.Set<T>();
        }

        #region IRepository
        public Key Add(T entity)
        {
            Table.Add(entity);
            Save();
            return entity.Id;
        }

        public void Update(T entity)
        {
            var efEntity = this.Context.Entry(entity);
            efEntity.State = EntityState.Modified;
            Save();
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
            Save();
        }

        public T Find(Key id)
        {
            return Table.Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return Table.FirstOrDefault(where);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            return Table.Where(where).AsEnumerable();
        }
        #endregion

        private void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
