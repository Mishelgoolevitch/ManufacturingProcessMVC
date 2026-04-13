namespace ManufacturingProcessMVC.Models
{
    public abstract class Instrument
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public abstract string Type { get; }

        public abstract void Prepare();
        public abstract void Execute();
    }
}
