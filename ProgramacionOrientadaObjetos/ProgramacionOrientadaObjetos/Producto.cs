using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionOrientadaObjetos
{
    internal class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }

        public Producto(int id, string nombre, float precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }

        public class ProductoCRUD
        {
            public List<Producto> productos = new List<Producto>();
            public int siguienteId = 1;

            public void CrearProducto()
            {
                Console.WriteLine("Ingrese el nombre del producto ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el precio de ese producto ");
                float precio = float.Parse(Console.ReadLine());

                Producto nuevoProducto = new Producto(siguienteId++, nombre, precio);
                productos.Add(nuevoProducto);
            }

            public void ListarProductos()
            {
                foreach (var producto in productos)
                {
                    Console.WriteLine($"ID: {producto.id}. Nombre: {producto.nombre}. Precio: {producto.precio}.");
                }
            }

            public void ActualizarProducto()
            {
                Console.WriteLine("Ingrese el ID del producto a actualizar: ");
                int id = int.Parse(Console.ReadLine());

                Producto producto = productos.Find(p => p.id == id);

                if (producto != null)
                {
                    Console.WriteLine("Ingrese el nuevo nombre del producto: ");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese el nuevo precio del producto: ");
                    float precio = float.Parse(Console.ReadLine());

                    producto.nombre = nombre;
                    producto.precio = precio;
                    Console.WriteLine("Producto actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }

            public void EliminarProducto()
            {
                Console.WriteLine("Ingrese el ID del producto a eliminar: ");
                int id = int.Parse(Console.ReadLine());

                Producto producto = productos.Find(p => p.id == id);

                if (producto != null)
                {
                    productos.Remove(producto);
                    Console.WriteLine("Producto eliminado exitosamente.");
                }

                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }   
        }
    }
}
