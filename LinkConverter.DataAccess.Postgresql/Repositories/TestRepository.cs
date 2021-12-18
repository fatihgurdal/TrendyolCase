using LinkConverter.Domain.DBEntity;
using LinkConverter.Domain.Repository;
using LinkConverter.Repository.Postgresql.Context;
using LinkConverter.Repository.Postgresql.Repositories.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Repository.Postgresql.Repositories
{
    public class TestRepository : RepositoryBase<TestEntity, int>, ITestRepository
    {
        internal TestRepository(LinkConverterContext dbContext) : base(dbContext)
        {
        }
    }
}
