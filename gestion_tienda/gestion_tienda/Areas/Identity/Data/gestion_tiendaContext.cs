using gestion_tienda.Areas.Identity.Data;
using gestion_tienda.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gestion_tienda.Data;

public class gestion_tiendaContext : IdentityDbContext<gestion_tiendaUser>
{
    public gestion_tiendaContext(DbContextOptions<gestion_tiendaContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
