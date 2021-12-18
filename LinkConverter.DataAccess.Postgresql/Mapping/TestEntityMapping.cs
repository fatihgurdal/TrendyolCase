using LinkConverter.Domain.DBEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkConverter.Repository.Postgresql.Mapping
{
    internal class TestEntityMapping : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.ToTable("TEST_ENTITIES");
            builder.Property(c => c.Id).HasColumnName("ID").UseIdentityColumn();
            builder.Property(c => c.Name).HasColumnName("NAME").HasMaxLength(500).IsRequired();
            builder.Property(c => c.Age).HasColumnName("AGE");
        }
    }
}
