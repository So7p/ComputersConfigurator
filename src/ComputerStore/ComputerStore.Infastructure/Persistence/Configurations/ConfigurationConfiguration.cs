using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.CpuId).IsRequired();
            builder.Property(c => c.GpuId).IsRequired();
            builder.Property(c => c.RamId).IsRequired();
            builder.Property(c => c.DriveId).IsRequired();
        }
    }
}
