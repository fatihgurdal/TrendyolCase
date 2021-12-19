using LinkConverter.Domain.Enums;

namespace LinkConverter.Domain.Models.Dto
{
    public class AddHistoryDto
    {
        public AddHistoryDto(string requestUrl, string responseUrl, LinkConvertType convertType)
        {
            RequestUrl = requestUrl;
            ResponseUrl = responseUrl;
            ConvertType = convertType;
        }
        public string RequestUrl { get; }

        public string ResponseUrl { get; }
        public LinkConvertType ConvertType { get; }
    }
}
