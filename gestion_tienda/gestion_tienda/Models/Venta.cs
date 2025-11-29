using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_tienda.Models
{
    public partial class Venta
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Total { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
    }
}
