using LinkConverter.Domain.Enums;

namespace LinkConverter.Domain.Exception
{
    public class BadRequestException : BaseException
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
