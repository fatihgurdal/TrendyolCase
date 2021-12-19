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
        public LinkConvertType ConvertType { get; set; }
        public string RequestLink { get; set; }
        public string ResponseLink { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
