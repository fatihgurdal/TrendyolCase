using LinkConverter.Domain.Repository;
using LinkConverter.Domain.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service
{
    public class TestService : ITestService
    {
        readonly ITestRepository Repository;

        public TestService(ITestRepository repository)
        {
            Repository = repository;
        }


        public int Add(string name, byte age)
        {
            return Repository.Add(new Domain.DBEntity.TestEntity()
            {
                Name = name,
                Age = age
            });
        }

        public string GetAll()
        {
            var entities = Repository.Get(x => true);

            return string.Join(", ", entities.Select(x => $"Name:{x.Name}, Age:{x.Age}"));
        }
    }
}
