namespace ManufacturingProcessMVC.Models
{
    public class ManufacturingProcess
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Status { get; set; } // Planned, InProgress, Completed

        // Навигационные свойства
        public int? DrillId { get; set; }
        public Drill? Drill { get; set; }

        public int? TapId { get; set; }
        public Tap? Tap { get; set; }

        public void ExecuteProcess()
        {
            Drill?.Prepare();
            Drill?.Execute();

            Tap?.Prepare();
            Tap?.Execute();

            Status = "Completed";
        }
    }
}
