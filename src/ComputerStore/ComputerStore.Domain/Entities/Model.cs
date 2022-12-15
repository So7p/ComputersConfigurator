using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class Model : BaseEntity
    { 
        public Configuration Configuration { get; set; } = null!;
        public int ConfigurationId { get; set; }

        public string Name { get; set; } = null!;

        public Computer Computer { get; set; } = null!;

        public ComputerBrand ComputerBrand { get; set; } = null!;
        public int ComputerBrandId { get; set; }
    }
}
