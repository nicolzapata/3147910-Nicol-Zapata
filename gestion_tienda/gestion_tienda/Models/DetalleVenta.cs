using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_tienda.Models
{
    public partial class DetalleVenta
    {
        public int Id { get; set; }

        [Required]
        public int VentaId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mínimo 1")]
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser positivo")]
        public decimal PrecioUnitario { get; set; }

        public virtual Productos? Producto { get; set; }
        public virtual Venta? Venta { get; set; }
    }
}
