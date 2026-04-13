using ManufacturingProcessMVC.Models;

namespace ManufacturingProcessMVC.Services
{
    public interface IManufacturingService
    {
        Task<ManufacturingProcess> CreateProcessAsync(int drillId, int tapId);
        Task ExecuteProcessAsync(int processId);
        Task<IEnumerable<ManufacturingProcess>> GetAllProcessesAsync();
        Task<ManufacturingProcess?> GetProcessByIdAsync(int id);
    }
}
