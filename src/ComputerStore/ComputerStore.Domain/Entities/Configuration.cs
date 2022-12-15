using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class Configuration : BaseEntity
    {
        /*public Model Model { get; set; } = null!;
        public int ModelId { get; set; }*/

        public CPU CPU { get; set; } = null!;
        public int CpuId { get; set; }

        public GPU GPU { get; set; } = null!;
        public int GpuId { get; set; }

        public RAM RAM { get; set; } = null!;
        public int RamId { get; set; }

        public Drive Drive { get; set; } = null!;
        public int DriveId { get; set; }
    }
}
