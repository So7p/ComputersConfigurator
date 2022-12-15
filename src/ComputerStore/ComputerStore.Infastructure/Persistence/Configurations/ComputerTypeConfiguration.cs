using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class ComputerTypeConfiguration : IEntityTypeConfiguration<ComputerType>
    {
        public void Configure(EntityTypeBuilder<ComputerType> builder)
        {
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(ct => ct.Type).HasMaxLength(20).IsRequired();
        }
    }
}
