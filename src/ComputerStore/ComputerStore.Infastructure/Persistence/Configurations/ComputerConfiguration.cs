using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class ComputerConfiguration : IEntityTypeConfiguration<Computer>
    {
        public void Configure(EntityTypeBuilder<Computer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(c => c.ModelId).IsRequired();

            builder.Property(c => c.Price).IsRequired();

            builder.Property(c => c.Quantity).IsRequired();

            builder.Property(c => c.ComputerTypeId).IsRequired();
        }

    }
}
