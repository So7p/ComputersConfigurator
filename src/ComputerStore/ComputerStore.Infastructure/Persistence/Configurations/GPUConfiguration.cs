using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class GPUConfiguration : IEntityTypeConfiguration<GPU>
    {
        public void Configure(EntityTypeBuilder<GPU> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();

            builder.Property(g => g.Manufacturer).IsRequired();

            builder.Property(g => g.Model).HasMaxLength(20).IsRequired();

            builder.Property(g => g.Vram).IsRequired();
        }
    }
}
