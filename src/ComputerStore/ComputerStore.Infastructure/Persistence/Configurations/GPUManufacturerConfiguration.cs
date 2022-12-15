using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class GPUManufacturerConfiguration : IEntityTypeConfiguration<GPUManufacturer>
    {
        public void Configure(EntityTypeBuilder<GPUManufacturer> builder)
        {
            builder.HasKey(gm => gm.Id);
            builder.Property(gm => gm.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(gm => gm.Name).HasMaxLength(10).IsRequired();
        }
    }
}
