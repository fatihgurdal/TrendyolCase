using LinkConverter.Domain.DBEntity;
using LinkConverter.Domain.Enums;
using LinkConverter.Domain.Repository.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Repository
{
    public interface ILinkConverterHistoryRepository : IRepository<LinkConverterHistory, int>
    {
        int AddHistory(string request, string response, LinkConvertType linkConvertType);
    }
}
