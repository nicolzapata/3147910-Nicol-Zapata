using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionOrientadaObjetos
{
    internal class Aprendiz //clase
    {
        //Atributos
        public string nombre { get; set; }
        public int edad { get; set; }
        public string direccion { get; set; }

        //Constructor
        public Aprendiz(string nombre, int edad, string direccion)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.direccion = direccion;
        }

        //Crear metodo para validar si es mayor de edad
        public void VerificarEdad()
        {
            if (edad >= 18)
            {
                Console.WriteLine($"{nombre} es mayor de edad.");
            }
            else
            {
                Console.WriteLine($"{nombre} es menor de edad.");
            }
        }
    }
}
