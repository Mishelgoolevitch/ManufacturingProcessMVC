using ManufacturingProcessMVC.Models;

namespace ManufacturingProcessMVC.Data.Repositories
{
    public interface IInstrumentRepository
    {
        Task<IEnumerable<Drill>> GetAllDrillsAsync();
        Task<IEnumerable<Tap>> GetAllTapsAsync();
        Task<Drill> GetDrillByIdAsync(int id);
        Task<Tap> GetTapByIdAsync(int id);
        Task AddDrillAsync(Drill drill);
        Task AddTapAsync(Tap tap);
    }
}
