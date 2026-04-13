using ManufacturingProcessMVC.Data;
using ManufacturingProcessMVC.Data.Repositories;
using ManufacturingProcessMVC.Models;
using ManufacturingProcessMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IInstrumentRepository, InstrumentRepository>();

// Services
builder.Services.AddScoped<IManufacturingService, ManufacturingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed initial data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    if (!context.Drills.Any())
    {
        context.Drills.AddRange(
            new Drill
            {
                Diameter = 10.2,
                Material = "HSS",
                Name = "Сверло стандартное 10.2мм"
            },
            new Drill
            {
                Diameter = 12.0,
                Material = "Кобальт",
                Name = "Сверло усиленное 12.0мм"
            },
            new Drill
            {
                Diameter = 5.0,
                Material = "HSS",
                Name = "Сверло тонкое 5.0мм"
            }
        );

        context.Taps.AddRange(
            new Tap
            {
                Size = "M10",
                ThreadType = "Метрическая",
                Name = "Метчик М10 стандартный"
            },
            new Tap
            {
                Size = "M12",
                ThreadType = "Метрическая",
                Name = "Метчик М12 усиленный"
            },
            new Tap
            {
                Size = "M8",
                ThreadType = "Метрическая",
                Name = "Метчик М8 тонкий"
            }
        );

        context.SaveChanges();
    }
}

app.Run();
