using LinkConverter.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Models.Response
{
    public class LinkConvertHistoryResponse
    {
        public int Id { get; set; }
        public LinkConvertType ConvertType { get; set; }
        public string RequestLink { get; set; }
        public string ResponseLink { get; set; }
        public DateTimeOffset Date { get; set; }
        public string DateFormated
        {
            get
            {
                return this.Date.ToString("dd MMM yyyy hh:mm:ss");
            }
        }

        public LinkConvertHistoryResponse()
        {

        }

        public LinkConvertHistoryResponse(DBEntity.LinkConverterHistory entity)
        {
            this.Id = entity.Id;
            this.ConvertType = entity.ConvertType;
            this.RequestLink = entity.RequestLink;
            this.ResponseLink = entity.ResponseLink;
            this.Date = entity.Date;
        }
    }
}
