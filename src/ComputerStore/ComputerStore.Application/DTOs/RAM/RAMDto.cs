using ComputerStore.Application.DTOs.Common;

namespace ComputerStore.Application.DTOs.RAM
{
    public class RAMDto : BaseDto
    {
        public int Value { get; set; }
        public string Type { get; set; } = null!;
        public int Frequency { get; set; }
    }
}
