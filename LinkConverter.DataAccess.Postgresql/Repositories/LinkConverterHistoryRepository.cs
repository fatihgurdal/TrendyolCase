using LinkConverter.Domain.DBEntity;
using LinkConverter.Domain.Enums;
using LinkConverter.Domain.Repository;
using LinkConverter.Repository.Postgresql.Context;
using LinkConverter.Repository.Postgresql.Repositories.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Repository.Postgresql.Repositories
{
    public class LinkConverterHistoryRepository : RepositoryBase<LinkConverterHistory, int>, ILinkConverterHistoryRepository
    {
        public LinkConverterHistoryRepository(LinkConverterContext dbContext) : base(dbContext)
        {
        }

        public int AddHistory(string request, string response, LinkConvertType linkConvertType)
        {
            return Add(new LinkConverterHistory()
            {
                Request = request,
                Response = response,
                Type = linkConvertType,
                Date = DateTime.Now,
            });
        }
    }
}
