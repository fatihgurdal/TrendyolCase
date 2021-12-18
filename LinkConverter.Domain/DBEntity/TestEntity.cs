using LinkConverter.Domain.DBEntity.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.DBEntity
{
    public class TestEntity : IDBEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
    }
}
