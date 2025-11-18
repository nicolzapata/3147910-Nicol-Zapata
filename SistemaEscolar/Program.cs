using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Models;

var builder = WebApplication.CreateBuilder(args);

// Validacion de la Base de Datos
builder.Services.AddDbContext<SistemaEscolarContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
