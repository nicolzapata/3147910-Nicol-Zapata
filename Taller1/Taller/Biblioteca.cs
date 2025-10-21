using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    internal class Biblioteca
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro) => libros.Add(libro);

        public void ListarLibros()
        {
            Console.WriteLine("\n--- LIBROS EN BIBLIOTECA ---");
            foreach (var libro in libros)
                Console.WriteLine($"{libro.Titulo} - {libro.Autor} ({libro.AnioPublicacion})");
        }

        public void BuscarLibro(string titulo)
        {
            foreach (var libro in libros)
                if (libro.Titulo.ToLower() == titulo.ToLower())
                {
                    Console.WriteLine($"Encontrado: {libro.Titulo} de {libro.Autor}");
                    return;
                }
            Console.WriteLine("Libro no encontrado.");
        }
    }
}
       
