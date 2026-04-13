namespace ManufacturingProcessMVC.Models
{
    public class Tap : Instrument
    {
        public override string Type => "Tap";
        public string? Size { get; set; } // М10, М12 и т.д.
        public string? ThreadType { get; set; }

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
