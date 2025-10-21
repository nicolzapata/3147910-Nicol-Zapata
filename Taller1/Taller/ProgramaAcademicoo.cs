using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    internal class ProgramaAcademicoo
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public double DescuentoEfectivo { get; set; }

        public ProgramaAcademico(string nombre, int creditos, double descuento)
        {
            Nombre = nombre;
            Creditos = creditos;
            DescuentoEfectivo = descuento;
        }
    }
}
