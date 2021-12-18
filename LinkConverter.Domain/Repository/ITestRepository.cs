using LinkConverter.Domain.DBEntity;
using LinkConverter.Domain.Repository.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Repository
{
    public interface ITestRepository : IRepository<TestEntity, int>
    {
    }
}
