using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class CPUConfiguration : IEntityTypeConfiguration<CPU>
    {
        public void Configure(EntityTypeBuilder<CPU> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Manufacturer).IsRequired();

            builder.Property(c => c.Model).HasMaxLength(15).IsRequired();
        }
    }
}
