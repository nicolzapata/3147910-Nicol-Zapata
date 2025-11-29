using Microsoft.EntityFrameworkCore;

namespace gestion_tienda.Models
{
    public partial class DbTiendaContext : DbContext
    {
        public DbTiendaContext(DbContextOptions<DbTiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Direccion).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(80);
                entity.Property(e => e.NombreCompleto).HasMaxLength(80);
                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.Producto)
                      .WithMany(p => p.DetalleVenta)
                      .HasForeignKey(d => d.ProductoId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Venta)
                      .WithMany(p => p.DetalleVenta)
                      .HasForeignKey(d => d.VentaId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Codigo).IsUnique();
                entity.Property(e => e.Codigo).HasMaxLength(20);
                entity.Property(e => e.Descripcion).HasMaxLength(200);
                entity.Property(e => e.Nombre).HasMaxLength(80);
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Fecha)
                      .HasDefaultValueSql("(getdate())")
                      .HasColumnType("datetime");
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.Cliente)
                      .WithMany(p => p.Venta)
                      .HasForeignKey(d => d.ClienteId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
