using ManufacturingProcessMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ManufacturingProcessMVC.ViewModels
{
    public class CreateProcessViewModel
    {
        [Required(ErrorMessage = "Выберите сверло")]
        [Display(Name = "Сверло")]
        public int SelectedDrillId { get; set; }

        [Required(ErrorMessage = "Выберите метчик")]
        [Display(Name = "Метчик")]
        public int SelectedTapId { get; set; }

        [Display(Name = "Название процесса")]
        [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов")]
        public string? ProcessName { get; set; }

        public IEnumerable<Drill> Drills { get; set; } = new List<Drill>();
        public IEnumerable<Tap> Taps { get; set; } = new List<Tap>();
    }
}
