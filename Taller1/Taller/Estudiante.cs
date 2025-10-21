using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    internal class Estudiante
    {
        public ProgramaAcademicoo Programa { get; set; }
        public string FormaPago { get; set; }

        public Estudiante(ProgramaAcademicoo programa, string formaPago)
        {
            Programa = programa;
            FormaPago = formaPago;
        }

        public double CalcularValor(double valorCredito)
        {
            double valorTotal = Programa.Creditos * valorCredito;
            double descuento = (FormaPago.ToLower() == "efectivo") ? valorTotal * Programa.DescuentoEfectivo : 0;
            return valorTotal - descuento;
        }
    }
}
