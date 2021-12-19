using LinkConverter.Domain.DBEntity.Base;
using LinkConverter.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.DBEntity
{
    public class LinkConverterHistory : IDBEntity<int>
    {
        public int Id { get; set; }
        public LinkConvertType Type { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
