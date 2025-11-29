using gestion_tienda.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gestion_tienda.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<gestion_tiendaUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
