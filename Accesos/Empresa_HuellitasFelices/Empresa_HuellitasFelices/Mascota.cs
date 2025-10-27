using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_HuellitasFelices
{
    internal class Mascota
    {
        // Atributos privados
        private string _nombre;
        private int _edad;
        private string _tipo;
        private double _peso;

        // Propiedades públicas para encapsular los atributos
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public int Edad
        {
            get => _edad;
            set
            {
                if (value >= 0)
                    _edad = value;
                else
                    throw new ArgumentException("La edad no puede ser negativa.");
            }
        }

        public string Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }

        public double Peso
        {
            get => _peso;
            set
            {
                if (value >= 0)
                    _peso = value;
                else
                    throw new ArgumentException("El peso no puede ser negativo.");
            }
        }

        // Mostrar información completa
        public void MostrarInformacion()
        {
            Console.WriteLine("----- Información de la Mascota -----");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad} años");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Peso: {Peso} kg");
        }

        // Calcular edad en años humanos
        public int CalcularEdadHumana()
        {
            string tipoLower = Tipo?.ToLower() ?? "";
            if (tipoLower == "perro")
            {
                return Edad * 7;
            }
            else if (tipoLower == "gato")
            {
                return Edad * 6;
            }
            else
            {
                return Edad;
            }
        }
    }
}