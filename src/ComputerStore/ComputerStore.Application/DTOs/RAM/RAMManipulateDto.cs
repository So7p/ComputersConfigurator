namespace ComputerStore.Application.DTOs.RAM
{
    public abstract class RAMManipulateDto
    {
        public int Value { get; set; }
        public string Type { get; set; } = null!;
        public int Frequency { get; set; }
    }
}
