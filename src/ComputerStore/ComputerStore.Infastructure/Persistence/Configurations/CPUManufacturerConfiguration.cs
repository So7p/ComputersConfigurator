using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class CPUManufacturerConfiguration : IEntityTypeConfiguration<CPUManufacturer>
    {
        public void Configure(EntityTypeBuilder<CPUManufacturer> builder)
        {
            builder.HasKey(cm => cm.Id);
            builder.Property(cm => cm.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(cm => cm.Name).HasMaxLength(10).IsRequired();
        }
    }
}
