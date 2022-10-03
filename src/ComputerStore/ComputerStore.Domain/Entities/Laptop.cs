using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class Laptop : BaseEntity
    {
        public int ModelId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Model Model { get; set; } = null!;
    }
}
