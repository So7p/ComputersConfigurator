namespace ComputerStore.Application.DTOs.Model
{
    public abstract class ModelManipulateDto
    {
        public string Name { get; set; } = null!;
        public int ConfigurationId { get; set; } 
        //public string ComputerBrandName { get; set; } = null!; 
        public int ComputerBrandId { get; set; }
    }
}