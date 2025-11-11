namespace Taller_proyectoMVC_NicolZapata.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int clienteID { get; set; }
        public int ProductoId { get; set; }
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }
    }
}
