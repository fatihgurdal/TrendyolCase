using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.DBEntity.Base
{
    public interface IDBEntity<T> where T : struct
    {
        public T Id { get; set; }
    }
}
