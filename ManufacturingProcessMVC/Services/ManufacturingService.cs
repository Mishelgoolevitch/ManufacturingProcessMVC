using ManufacturingProcessMVC.Data;
using ManufacturingProcessMVC.Data.Repositories;
using ManufacturingProcessMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingProcessMVC.Services
{
    public class ManufacturingService : IManufacturingService
    {
        private readonly IInstrumentRepository _instrumentRepository;
        private readonly ApplicationDbContext _context;

        public ManufacturingService(
            IInstrumentRepository instrumentRepository,
            ApplicationDbContext context)
        {
            _instrumentRepository = instrumentRepository;
            _context = context;
        }

        public async Task<ManufacturingProcess> CreateProcessAsync(int drillId, int tapId)
        {
            var drill = await _instrumentRepository.GetDrillByIdAsync(drillId);
            var tap = await _instrumentRepository.GetTapByIdAsync(tapId);

            var process = new ManufacturingProcess
            {
                DrillId = drillId,
                TapId = tapId,
                Name = $"Process_{DateTime.Now:yyyyMMdd_HHmmss}",
                CreatedDate = DateTime.Now,
                Status = "Planned"
            };

            _context.Processes.Add(process);
            await _context.SaveChangesAsync();

            return process;
        }

        Task IManufacturingService.ExecuteProcessAsync(int processId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ManufacturingProcess>> IManufacturingService.GetAllProcessesAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<ManufacturingProcess?> GetProcessByIdAsync(int id)
        {
            return await _context.Processes
                .Include(p => p.Drill)
                .Include(p => p.Tap)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
