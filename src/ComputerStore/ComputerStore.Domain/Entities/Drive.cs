using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class Drive : BaseEntity
    {
        public int MemoryValue { get; set; }

        public DriveType DriveType { get; set; } = null!;
        public int DriveTypeId { get; set; }

        public ICollection<Configuration> Configurations { get; set; } = null!;
    }
}
