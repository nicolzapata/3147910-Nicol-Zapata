using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using gestion_tienda.Models;
using gestion_tienda.Areas.Identity.Data;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Conexiones
var identityConn = builder.Configuration.GetConnectionString("IdentityConnection")
    ?? throw new Exception("Falta IdentityConnection en appsettings.json");

var tiendaConn = builder.Configuration.GetConnectionString("TiendaConnection")
    ?? throw new Exception("Falta TiendaConnection en appsettings.json");

// DbContext de Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(identityConn));

// DbContext de Tienda
builder.Services.AddDbContext<DbTiendaContext>(options =>
    options.UseSqlServer(tiendaConn));

// Identity con roles
builder.Services.AddDefaultIdentity<gestion_tiendaUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Autorización global: solo requiere usuario autenticado
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
})
.AddRazorPagesOptions(options =>
{
    options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/Login");
    options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/Register");
    options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/Logout");
    options.Conventions.AllowAnonymousToAreaFolder("Identity", "/Account");
});

var app = builder.Build();

// Migraciones + SeedData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var identityDb = services.GetRequiredService<ApplicationDbContext>();
        var tiendaDb = services.GetRequiredService<DbTiendaContext>();

        // Aplicar migraciones
        identityDb.Database.Migrate();
        tiendaDb.Database.Migrate();

        // Ejecutar SeedData
        await SeedData.InitializeAsync(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error aplicando migraciones o SeedData.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
