using LinkConverter.Domain.Enums;
namespace LinkConverter.Domain.Exception
{
    public class BaseException : System.Exception
    {
        public override string Message { get; }
        public string Detail { get; }
        public ErrorType Type { get; }
        public BaseException(string message) : this(message, string.Empty)
        {

        }
        public BaseException(string message, string detail) : this(message, detail, ErrorType.Critical)
        {
        }
        public BaseException(string message, string detail, ErrorType type) : base(message)
        {
            Message = message;
            Detail = detail;
            Type = type;
        }
    }
}
