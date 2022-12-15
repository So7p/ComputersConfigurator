using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class ComputerBrandConfiguration : IEntityTypeConfiguration<ComputerBrand>
    {
        public void Configure(EntityTypeBuilder<ComputerBrand> builder)
        {
            builder.HasKey(cb => cb.Id);
            builder.Property(cb => cb.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(cb => cb.Name).HasMaxLength(15).IsRequired();
        }
    }
}
