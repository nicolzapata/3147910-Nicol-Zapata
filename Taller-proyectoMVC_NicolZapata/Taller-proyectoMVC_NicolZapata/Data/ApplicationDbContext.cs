using Microsoft.EntityFrameworkCore;
using Taller_proyectoMVC_NicolZapata.Models;

namespace Taller_proyectoMVC_NicolZapata.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
        options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public object Ventas { get; internal set; }
    }
}
