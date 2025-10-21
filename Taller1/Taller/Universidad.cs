using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    internal class Universidad
    {
        public List<ProgramaAcademicoo> Programas = new List<ProgramaAcademicoo>();
        public List<Estudiante> Estudiantes = new List<Estudiante>();
        public double ValorCredito = 200000;

        public Universidad()
        {
            Programas.Add(new ProgramaAcademicoo("Ingeniería de Sistemas", 20, 0.18));
            Programas.Add(new ProgramaAcademicoo("Psicología", 16, 0.12));
            Programas.Add(new ProgramaAcademicoo("Economía", 18, 0.10));
            Programas.Add(new ProgramaAcademicoo("Comunicación Social", 18, 0.05));
            Programas.Add(new ProgramaAcademicoo("Administración de Empresas", 20, 0.15));
        }

        public void MatricularEstudiante()
        {
            Console.WriteLine("\nSeleccione el programa académico:");
            for (int i = 0; i < Programas.Count; i++)
                Console.WriteLine($"{i + 1}. {Programas[i].Nombre}");

            int opcion = int.Parse(Console.ReadLine()) - 1;
            ProgramaAcademicoo programaSeleccionado = Programas[opcion];

            Console.Write("Forma de pago (Efectivo / En línea): ");
            string pago = Console.ReadLine();

            Estudiantes.Add(new Estudiante(programaSeleccionado, pago));
        }

        public void MostrarResultados()
        {
            Console.WriteLine("\n--- RESULTADOS ---");
            int[] inscritosPorPrograma = new int[Programas.Count];
            double totalCreditos = 0, totalSinDesc = 0, totalDesc = 0, totalNeto = 0;

            foreach (var estudiante in Estudiantes)
            {
                int index = Programas.IndexOf(estudiante.Programa);
                inscritosPorPrograma[index]++;

                double valor = estudiante.Programa.Creditos * ValorCredito;
                double descuento = (estudiante.FormaPago.ToLower() == "efectivo") ? valor * estudiante.Programa.DescuentoEfectivo : 0;

                totalCreditos += estudiante.Programa.Creditos;
                totalSinDesc += valor;
                totalDesc += descuento;
                totalNeto += valor - descuento;
            }

            for (int i = 0; i < Programas.Count; i++)
                Console.WriteLine($"{Programas[i].Nombre}: {inscritosPorPrograma[i]} estudiantes");

            Console.WriteLine($"\nTotal créditos inscritos: {totalCreditos}");
            Console.WriteLine($"Valor total sin descuento: ${totalSinDesc}");
            Console.WriteLine($"Total descuentos aplicados: ${totalDesc}");
            Console.WriteLine($"Valor neto de inscripciones: ${totalNeto}");
        }
    }
}

