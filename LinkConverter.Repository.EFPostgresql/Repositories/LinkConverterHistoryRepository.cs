using LinkConverter.Domain.DBEntity;
using LinkConverter.Domain.Models.Dto;
using LinkConverter.Domain.Repository;
using LinkConverter.Repository.EFPostgresql.Context;
using LinkConverter.Repository.EFPostgresql.Repositories.Base;

using Microsoft.EntityFrameworkCore;

using System;

namespace LinkConverter.Repository.EFPostgresql.Repositories
{
    public class LinkConverterHistoryRepository : RepositoryBase<LinkConverterHistory, int>, ILinkConverterHistoryRepository
    {
        public LinkConverterHistoryRepository(LinkConverterContext dbContext) : base(dbContext)
        {
        }

        public int AddHistory(AddHistoryDto addHistory)
        {
            return Add(new LinkConverterHistory()
            {
                RequestLink = addHistory.RequestUrl,
                ResponseLink = addHistory.ResponseUrl,
                ConvertType = addHistory.ConvertType,
                Date = DateTime.Now,
            });
        }

        public void Clear()
        {
            Context.Database.ExecuteSqlCommand("TRUNCATE \"LINKCONVERT_HISTORIES\"");
        }
    }
}
