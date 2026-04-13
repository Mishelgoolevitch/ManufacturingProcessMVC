using Microsoft.EntityFrameworkCore;
using ManufacturingProcessMVC.Models;
using ManufacturingProcessMVC.Data;

namespace ManufacturingProcessMVC.Data.Repositories
{
    public class InstrumentRepository: IInstrumentRepository
    {
        private readonly ApplicationDbContext _context;
        
        public InstrumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Drill>> GetAllDrillsAsync()
        {
            return await _context.Drills.ToListAsync();
        }
        
        public async Task<IEnumerable<Tap>> GetAllTapsAsync()
        {
            return await _context.Taps.ToListAsync();
        }
        
        public async Task<Drill?> GetDrillByIdAsync(int id)
        {
            return await _context.Drills.FindAsync(id);
        }
        
        public async Task<Tap?> GetTapByIdAsync(int id)
        {
            return await _context.Taps.FindAsync(id);
        }
        
        public async Task AddDrillAsync(Drill drill)
        {
            _context.Drills.Add(drill);
            await _context.SaveChangesAsync();
        }
        
        public async Task AddTapAsync(Tap tap)
        {
            _context.Taps.Add(tap);
            await _context.SaveChangesAsync();
        }
    }
}
