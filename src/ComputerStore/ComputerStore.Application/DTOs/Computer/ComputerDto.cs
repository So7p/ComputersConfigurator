using ComputerStore.Application.DTOs.Common;

namespace ComputerStore.Application.DTOs.Computer
{
    public class ComputerDto : BaseDto
    {
        public string ModelName { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; } = null!;
    }
}
