using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        public Persona(string nombre, int edad, string genero, string telefono)
        {
            Nombre = nombre;
            Edad = edad;
            Genero = genero;
            Telefono = telefono;
        }
        public void ImprimirDetalles()
        {
            Console.WriteLine($"\nNombre: {Nombre}\nEdad: {Edad}\nGénero: {Genero}\nTeléfono: {Telefono}");
        }

        public void CalcularEdadEnDias()
        {
            Console.WriteLine($"Edad en días: {Edad * 365}");
        }
    }
}
