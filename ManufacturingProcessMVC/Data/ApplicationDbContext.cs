using ManufacturingProcessMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingProcessMVC.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Drill> Drills { get; set; }
        public DbSet<Tap> Taps { get; set; }
        public DbSet<ManufacturingProcess> Processes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                 modelBuilder.Entity<Instrument>()
                .HasDiscriminator<string>("InstrumentType")
                .HasValue<Drill>("Drill")
                .HasValue<Tap>("Tap");
        }
    }
}
