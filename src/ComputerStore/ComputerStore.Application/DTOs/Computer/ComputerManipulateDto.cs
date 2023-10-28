namespace ComputerStore.Application.DTOs.Computer
{
    public abstract class ComputerManipulateDto
    {
        //public string ModelName { get; set; } = null!;
        public int ModelId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        //public string Type { get; set; } = null!; 
        public int ComputerTypeId { get; set; }
    }
}
