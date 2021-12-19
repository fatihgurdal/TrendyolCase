using LinkConverter.Domain.DBEntity;
using LinkConverter.Domain.Models.Dto;
using LinkConverter.Domain.Repository.Base;

namespace LinkConverter.Domain.Repository
{
    public interface ILinkConverterHistoryRepository : IRepository<LinkConverterHistory, int>
    {
        int AddHistory(AddHistoryDto addHistory);
    }
}
