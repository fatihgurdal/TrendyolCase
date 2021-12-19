using LinkConverter.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Exception
{
    public class NotFoundExcepiton : BaseExcepiton
    {
        public NotFoundExcepiton(string message) : this(message, string.Empty)
        {

        }
        public NotFoundExcepiton(string message, string detail) : this(message, detail, ErrorType.Critical)
        {
        }
        public NotFoundExcepiton(string message, string detail, ErrorType type) : base(message, detail, type)
        {
        }
    }
}
