using System.ComponentModel.DataAnnotations;

namespace gestion_tienda.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [StringLength(80)]
        public string NombreCompleto { get; set; } = null!;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(80)]
        public string Email { get; set; } = null!;

        [StringLength(100)]
        public string? Direccion { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
    }
}
