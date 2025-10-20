using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ejercicio1
            //Console.WriteLine("Ingrese un número: ");
            //   int numero = int.Parse(Console.ReadLine());
            //   if (numero % 2 == 0)
            //     {
            //         Console.WriteLine("El número que usted ingreso es: " + numero + " es par");
            //     }
            //     else
            //     {
            //         Console.WriteLine($"El número que usted ingreso {numero} es impar");
            // }

            //ejercicio2
            //Console.WriteLine("Ingrese su primera nota: ");
            //double nota1 = double.Parse(Console.ReadLine());

            //Console.WriteLine("Ingrese su segunda nota: ");
            //double nota2 = double.Parse(Console.ReadLine());

            //Console.WriteLine("Ingrese su tercer nota: ");
            //double nota3 = double.Parse(Console.ReadLine());

            //double definitiva = (nota1 * 0.2) + (nota2 * 0.3) + (nota3 * 0.5);

            //Console.WriteLine("La nota definitiva es: " + definitiva);

            //if (definitiva >=3)
            //{
            //    Console.WriteLine("Aprobó");
            //}

            //else
            //{
            //    Console.WriteLine("Reprobó");
            //}

            //ejercicio3
            //Console.WriteLine("Ingrese el precio del producto:");
            //double precio = double.Parse(Console.ReadLine());

            //double precioFinal;

            //if(precio >= 100000)
            //{
            //    precioFinal = precio - (precio * 0.2); // Aplica un descuento del 10%
            //}
            //else
            //{
            //    precioFinal = precio; // No hay descuento
            //}
            //Console.WriteLine("El precio final es: " + precioFinal);


            //TALLER ESTRUCTURA DE CONTROL

            //ejercicio1
            //    Console.WriteLine("Ingrese el monto del prestamo: ");
            //    double monto = double.Parse(Console.ReadLine());
            //    double tasa = 0.05;
            //    double año = 5;

            //    double interesAnual = monto * tasa;
            //    double interesTrimestre3 = interesAnual /4;

            //    double interesPrimerMes = interesAnual / 12;
            //    double totalConInteres = monto + (interesAnual * año);

            //    Console.WriteLine("interes en un año: " + interesAnual);
            //    Console.WriteLine("Interes en el tercer trimestre: "+ interesTrimestre3);
            //    Console.WriteLine("Interes en el primer mes: " + interesPrimerMes);
            //    Console.WriteLine("Total a pagar (5 años): "+  totalConInteres);

            //ejercicio2
            //Console.WriteLine("Salario del empleado: ");
            //double salario = double.Parse(Console.ReadLine());

            //Console.WriteLine("Valor de ahorro mensual: ");
            //double  ahorro = double.Parse(Console.ReadLine());

            //double salud = salario * 0.125;
            //double pension = salario * 0.16;
            //double total = salario - (salud + pension + ahorro);

            //Console.WriteLine("\n--- Colilla de Pago ---");
            //Console.WriteLine("Salario:" + salario);
            //Console.WriteLine("Ahorro mensual: " + ahorro);
            //Console.WriteLine("Descuento pension (16%): " + pension);
            //Console.WriteLine("Total a recibir: " + total);


            //POO
            //int[] numeros = new int[3];
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine("Ingrese un número: " + (i + 1) + ": ");
            //    numeros[i] = int.Parse(Console.ReadLine());
            //}
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine("Número" + (i + 1) +  ": " + numeros[i]);
            //}


            //EJERCICIOS DE LISTA
            List<int> numero = new List<int>();

            numero.Add(10);
            numero.Add(20);
            numero.Add(30);

            Console.WriteLine("Los números de la lista son: ");
            foreach (int i in numero)
            {
                Console.WriteLine(1);
            }
            int segundoNumero = numero[1];
            Console.WriteLine("El segundo numero de a lista es: " + segundoNumero);

            numero[1] = 25;
            Console.WriteLine("La lista después de modificar el segundo número: ");
            foreach (int i in numero)
            {
                Console.WriteLine(1);
            }

            numero.Insert(0, 15);
            Console.WriteLine("La lista después de insertar 15 en la posición 1: ");
            foreach (int i in numero)
            {
                Console.WriteLine(i);
            }

            numero.Remove(30);
            Console.WriteLine("La lista después de eliminar número 30: ");
            foreach (int i in numero)
            {
                Console.WriteLine(i);
            }
            numero.Remove(30);
            Console.WriteLine("La lista después de eliminar número 30: ");
            foreach (int i in numero)
            {
                Console.WriteLine(i);
            }

            numero.Sort();
            Console.WriteLine("La lista después de ordenar:");
            foreach (int i in numero)
            {
                Console.WriteLine(i);
            }

        }
    }
}
