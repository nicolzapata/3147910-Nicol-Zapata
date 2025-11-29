using Microsoft.AspNetCore.Identity;

namespace gestion_tienda.Models
{
    // Usuario personalizado — añade propiedades si las necesitas (e.g. NombreCompleto)
    public class gestion_tiendaUser : IdentityUser
    {
        public string? NombreCompleto { get; set; }
    }
}
