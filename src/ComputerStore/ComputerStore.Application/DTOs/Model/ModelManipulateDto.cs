namespace ComputerStore.Application.DTOs.Model
{
    public abstract class ModelManipulateDto
    {
        public string Name { get; set; } = null!;
        public int ConfigurationId { get; set; } // Mapping Configurations.Id from Configurations
        public string ComputerBrandName { get; set; } = null!; // Mapping ComputerBrands.Name from ComputerBrands
    }
}
