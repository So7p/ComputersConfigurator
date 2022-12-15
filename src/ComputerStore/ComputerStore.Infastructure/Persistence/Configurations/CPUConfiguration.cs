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
            builder.Property(c => c.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(c => c.CPUManufacturerId).IsRequired();

            builder.Property(c => c.Model).HasMaxLength(15).IsRequired();

            builder.Property(c => c.Cores).IsRequired();
        }
    }
}
