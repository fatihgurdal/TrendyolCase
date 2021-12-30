using LinkConverter.Repository.EFPostgresql.Mapping;
using LinkConverter.Domain.DBEntity;

using Microsoft.EntityFrameworkCore;

namespace LinkConverter.Repository.EFPostgresql.Context
{
    public class LinkConverterContext : DbContext
    {
        #region Ctor
        public LinkConverterContext(DbContextOptions<LinkConverterContext> options) : base(options)
        {
        }
        #endregion

        #region Tables
        public DbSet<LinkConverterHistory> LinkConverterHistories { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LinkConverterHistoryMapping());

        }
        #endregion
    }
}
