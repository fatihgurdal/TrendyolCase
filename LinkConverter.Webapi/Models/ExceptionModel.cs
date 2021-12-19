using LinkConverter.Domain.Enums;

using System;

namespace LinkConverter.Webapi.Models
{
    public class ExceptionModel
    {
        public Guid TraceId { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public ErrorType Type { get; set; }
    }
}
