using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionOrientadaObjetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Objeto de la clase auto
            Auto coche1 = new Auto("Toyota", "Corolla", 2023);
            Auto coche2 = new Auto("Ford", "F-150", 2022);

            coche1.MostrarInfo(); //Se llama al metodo para mostrar la info.
            coche2.MostrarInfo();

            coche1.anio = 2027; //Se cambia la info del anio.
            coche1.MostrarInfo();

            //--------------------------------------------------------------

            //Objeto de la clase aprendiz
            Aprendiz aprendiz1 = new Aprendiz("Nicol", 17, "Cll23#45-11");

            aprendiz1.VerificarEdad();

            //--- Otra forma de hacerlo ---
            Console.WriteLine("Ingrese el nombre del aprendiz: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del aprendiz: ");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la direccion del aprendiz: ");
            string direccion = Console.ReadLine();

            Aprendiz estudiante = new Aprendiz(nombre, edad, direccion);

            estudiante.VerificarEdad();

            //--------------------------------------------------------------

            //Objeto de la clase producto
            Producto.ProductoCRUD productoCRUD = new Producto.ProductoCRUD();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Seleccione una opcion: ");
                Console.WriteLine("1. Crear producto");
                Console.WriteLine("2. Listar productos");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Salir");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        productoCRUD.CrearProducto();
                        break;

                    case 2:
                        productoCRUD.ListarProductos();
                        break;

                    case 3:
                        productoCRUD.ActualizarProducto();
                        break;

                    case 4:
                        productoCRUD.EliminarProducto();
                        break;

                    case 5:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
