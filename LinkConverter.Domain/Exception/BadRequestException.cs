using LinkConverter.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Exception
{
    public class BadRequestException : BaseExcepiton
    {
        public BadRequestException(string message) : this(message, string.Empty)
        {

        }
        public BadRequestException(string message, string detail) : this(message, detail, ErrorType.Critical)
        {
        }
        public BadRequestException(string message, string detail, ErrorType type) : base(message, detail, type)
        {
        }
    }
}
