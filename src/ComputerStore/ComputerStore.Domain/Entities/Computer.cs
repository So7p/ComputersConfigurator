using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class Computer : BaseEntity  
    {
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Model Model { get; set; } = null!; 
        public int ModelId { get; set; }

        public ComputerType ComputerType { get; set; } = null!;
        public int ComputerTypeId { get; set; }
    }
}
