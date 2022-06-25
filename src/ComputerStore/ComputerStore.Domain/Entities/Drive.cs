using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class Drive : BaseEntity
    {
        public Enums.DriveType DriveType { get; set; }
        public int Value { get; set; }

        public ICollection<Configuration> Configurations { get; set; } = null!;
    }
}
