using LinkConverter.Domain.DBEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkConverter.Repository.EFPostgresql.Mapping
{
    public class LinkConverterHistoryMapping : IEntityTypeConfiguration<LinkConverterHistory>
    {
        public void Configure(EntityTypeBuilder<LinkConverterHistory> builder)
        {
            builder.ToTable("LINKCONVERT_HISTORIES");
            builder.Property(c => c.Id).HasColumnName("ID").UseIdentityColumn();
            builder.Property(c => c.RequestLink).HasColumnName("REQUEST_LINK").IsRequired();
            builder.Property(c => c.ResponseLink).HasColumnName("RESPONSE_LINK").IsRequired();
            builder.Property(c => c.ConvertType).HasColumnName("CONVERT_TYPE").IsRequired();
        }
    }
}
