using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class Model : BaseEntity
    {
        public int ConfigurationId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Laptop> Laptops { get; set; } = null!;
        public Configuration Configuration { get; set; } = null!;
    }
}
