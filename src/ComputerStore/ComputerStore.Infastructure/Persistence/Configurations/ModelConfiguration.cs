using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(m => m.ConfigurationId).IsRequired();

            builder.Property(m => m.Name).HasMaxLength(20).IsRequired();

            builder.Property(m => m.ComputerBrandId).IsRequired();

        }
    }
}
