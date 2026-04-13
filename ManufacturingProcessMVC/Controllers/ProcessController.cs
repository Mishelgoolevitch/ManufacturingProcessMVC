using ManufacturingProcessMVC.Data.Repositories;
using ManufacturingProcessMVC.Services;
using ManufacturingProcessMVC.Models;
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

        public async Task<IActionResult> Index()
        {
            var processes = await _manufacturingService.GetAllProcessesAsync();
            return View(processes);
        }

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

        [HttpPost]
        public async Task<IActionResult> Create(CreateProcessViewModel model)
        {
            if (ModelState.IsValid)
            {
                var process = await _manufacturingService
                    .CreateProcessAsync(model.SelectedDrillId, model.SelectedTapId);

                return RedirectToAction("Details", new { id = process.Id });
            }

            // Если модель невалидна, перезагружаем данные
            model.Drills = await _instrumentRepository.GetAllDrillsAsync();
            model.Taps = await _instrumentRepository.GetAllTapsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Execute(int id)
        {
            await _manufacturingService.ExecuteProcessAsync(id);
            return RedirectToAction("Details", new { id });
        }
    }
}
