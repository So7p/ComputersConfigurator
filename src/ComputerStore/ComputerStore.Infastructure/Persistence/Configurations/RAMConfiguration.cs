using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class RAMConfiguration : IEntityTypeConfiguration<RAM>
    {
        public void Configure(EntityTypeBuilder<RAM> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(r => r.Value).IsRequired();

            builder.Property(r => r.Type).HasMaxLength(10).IsRequired();

            builder.Property(r => r.Frequency).IsRequired();
        }
    }
}
