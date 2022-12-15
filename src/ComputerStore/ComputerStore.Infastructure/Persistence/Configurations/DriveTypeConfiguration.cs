using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerStore.Infastructure.Persistence.Configurations
{
    public class DriveTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.DriveType>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.DriveType> builder)
        {
            builder.HasKey(dt => dt.Id);
            builder.Property(dt => dt.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(dt => dt.Type).HasMaxLength(10).IsRequired();
        }
    }
}
