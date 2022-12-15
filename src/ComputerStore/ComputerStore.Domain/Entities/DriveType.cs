using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class DriveType : BaseEntity
    {
        public string Type { get; set; } = null!;

        public ICollection<Drive> Drives { get; set; } = null!;
    }
}
