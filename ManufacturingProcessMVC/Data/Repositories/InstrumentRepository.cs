using ManufacturingProcessMVC.Models;

namespace ManufacturingProcessMVC.Data.Repositories
{
    public class InstrumentRepository: IInstrumentRepository
    {
        private readonly ApplicationDbContext _context;

        public InstrumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddDrillAsync(Drill drill)
        {
            throw new NotImplementedException();
        }

        public Task AddTapAsync(Tap tap)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Drill>> GetAllDrillsAsync()
        {
            throw new NotImplementedException();
            //return await _context.Drills.ToListAsync();
        }

        public Task<IEnumerable<Tap>> GetAllTapsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Drill> GetDrillByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tap> GetTapByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
