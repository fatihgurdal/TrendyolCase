using LinkConverter.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Exception
{
    public class BaseExcepiton : System.Exception
    {
        public override string Message { get; }
        public string Detail { get; }
        public ErrorType Type { get; }
        public BaseExcepiton(string message) : this(message, string.Empty)
        {

        }
        public BaseExcepiton(string message, string detail) : this(message, detail, ErrorType.Critical)
        {
        }
        public BaseExcepiton(string message, string detail, ErrorType type) : base(message)
        {
            Message = message;
            Detail = detail;
            Type = type;
        }
    }
}
