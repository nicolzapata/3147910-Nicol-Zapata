namespace gestion_tienda.Models
{
    public class VentaItemViewModel
    {
        public int ProductoId { get; set; }
        public string? ProductoNombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
    }
}
