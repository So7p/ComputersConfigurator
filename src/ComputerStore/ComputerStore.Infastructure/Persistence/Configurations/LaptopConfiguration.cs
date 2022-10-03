using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class LaptopConfiguration : IEntityTypeConfiguration<Laptop>
    {
        public void Configure(EntityTypeBuilder<Laptop> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();

            builder.Property(l => l.ModelId).IsRequired();

            builder.Property(l => l.Price).IsRequired();

            builder.Property(l => l.Quantity).IsRequired();
        }

    }
}
