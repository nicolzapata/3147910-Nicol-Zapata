using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    internal class Libro
    {
        public string Titulo, Autor, Editorial;
        public int AnioPublicacion;

        public Libro(string titulo, string autor, string editorial, int anio)
        {
            Titulo = titulo; Autor = autor; Editorial = editorial; AnioPublicacion = anio;
        }
    }
}
