using ManufacturingProcessMVC.Data.Repositories;
using ManufacturingProcessMVC.Services;
using ManufacturingProcessMVC.ViewModels;
using ManufacturingProcessMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ManufacturingProcessMVC.Controllers
{
    public class ProcessController:Controller
    {
        private readonly IManufacturingService _manufacturingService;
        private readonly IInstrumentRepository _instrumentRepository;

        public ProcessController(
            IManufacturingService manufacturingService,
            IInstrumentRepository instrumentRepository)
        {
            _manufacturingService = manufacturingService;
            _instrumentRepository = instrumentRepository;
        }

        // GET: Process
        public async Task<IActionResult> Index()
        {
            var processes = await _manufacturingService.GetAllProcessesAsync();
            return View(processes);
        }

        // GET: Process/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateProcessViewModel
            {
                Drills = await _instrumentRepository.GetAllDrillsAsync(),
                Taps = await _instrumentRepository.GetAllTapsAsync()
            };

            return View(viewModel);
        }

        // POST: Process/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProcessViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var process = await _manufacturingService
                        .CreateProcessAsync(model.SelectedDrillId, model.SelectedTapId);

                    TempData["SuccessMessage"] = $"Процесс '{process.Name}' успешно создан!";
                    return RedirectToAction("Details", new { id = process.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Ошибка при создании процесса: {ex.Message}");
                }
            }

            // Если модель невалидна, перезагружаем данные для dropdown
            model.Drills = await _instrumentRepository.GetAllDrillsAsync();
            model.Taps = await _instrumentRepository.GetAllTapsAsync();

            return View(model);
        }

        // GET: Process/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var process = await _manufacturingService.GetProcessByIdAsync(id);
            if (process == null)
            {
                return NotFound();
            }

            return View(process);
        }

        // POST: Process/Execute/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Execute(int id)
        {
            try
            {
                await _manufacturingService.ExecuteProcessAsync(id);
                TempData["SuccessMessage"] = "Процесс успешно выполнен!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ошибка выполнения: {ex.Message}";
            }

            return RedirectToAction("Details", new { id });
        }
    }
}
