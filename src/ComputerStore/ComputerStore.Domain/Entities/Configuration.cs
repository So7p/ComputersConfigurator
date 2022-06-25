using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class Configuration : BaseEntity
    {
        public int CpuId { get; set; }
        public int GpuId { get; set; }
        public int RamId { get; set; }
        public int DriveId { get; set; }

        public ICollection<Model> Models { get; set; } = null!;
        public CPU CPU { get; set; } = null!;
        public GPU GPU { get; set; } = null!;
        public RAM RAM { get; set; } = null!;
        public Drive Drive { get; set; } = null!;
    }
}
