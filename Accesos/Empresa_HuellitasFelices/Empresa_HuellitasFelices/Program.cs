using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_HuellitasFelices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo de uso interactivo
            Mascota mascota1 = CrearMascotaDesdeConsola("primera");
            Mascota mascota2 = CrearMascotaDesdeConsola("segunda");

            Console.WriteLine();
            mascota1.MostrarInformacion();
            Console.WriteLine($"Edad en años humanos: {mascota1.CalcularEdadHumana()} años\n");

            mascota2.MostrarInformacion();
            Console.WriteLine($"Edad en años humanos: {mascota2.CalcularEdadHumana()} años\n");

            Console.WriteLine("Presione Enter para salir...");
            Console.ReadLine();
        }

        private static Mascota CrearMascotaDesdeConsola(string orden)
        {
            Mascota m = new Mascota();

            Console.WriteLine($"Ingrese los datos de la {orden} mascota:");

            Console.Write("Nombre: ");
            m.Nombre = Console.ReadLine();

            Console.Write("Edad (años): ");
            if (int.TryParse(Console.ReadLine(), out int edad))
                m.Edad = edad;
            else
                m.Edad = 0;

            Console.Write("Tipo (perro, gato, otro): ");
            m.Tipo = Console.ReadLine();

            Console.Write("Peso (kg): ");
            if (double.TryParse(Console.ReadLine(), out double peso))
                m.Peso = peso;
            else
                m.Peso = 0.0;

            Console.WriteLine();

            return m;
        }
    }
}
