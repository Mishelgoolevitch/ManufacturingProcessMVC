namespace ManufacturingProcessMVC.Models
{
    public class Drill : Instrument
    {
        public override string Type => "Drill";
        public double Diameter { get; set; } // мм
        public string? Material { get; set; }

        public override void Prepare()
        {
            // Логика подготовки
        }

        public override void Execute()
        {
            // Логика выполнения
        }
    }
}
