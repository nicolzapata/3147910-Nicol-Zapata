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







            //---------------------------//TALLER ESTRUCTURA DE CONTROL-------------------------------------------------

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


            //------------------------------------//POO-----------------------------------------------
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






            //-------------------------------------EJERCICIOS DE LISTA---------------------------------------
            //List<int> numero = new List<int>();

            //numero.Add(10);
            //numero.Add(20);
            //numero.Add(30);

            //Console.WriteLine("Los números de la lista son: ");
            //foreach (int i in numero)
            //{
            //    Console.WriteLine(1);
            //}
            //int segundoNumero = numero[1];
            //Console.WriteLine("El segundo numero de a lista es: " + segundoNumero);

            //numero[1] = 25;
            //Console.WriteLine("La lista después de modificar el segundo número: ");
            //foreach (int i in numero)
            //{
            //    Console.WriteLine(1);
            //}

            //numero.Insert(0, 15);
            //Console.WriteLine("La lista después de insertar 15 en la posición 1: ");
            //foreach (int i in numero)
            //{
            //    Console.WriteLine(i);
            //}

            //numero.Remove(30);
            //Console.WriteLine("La lista después de eliminar número 30: ");
            //foreach (int i in numero)
            //{
            //    Console.WriteLine(i);
            //}
            //numero.Remove(30);
            //Console.WriteLine("La lista después de eliminar número 30: ");
            //foreach (int i in numero)
            //{
            //    Console.WriteLine(i);
            //}

            //numero.Sort();
            //Console.WriteLine("La lista después de ordenar:");
            //foreach (int i in numero)
            //{
            //    Console.WriteLine(i);
            //}




            //-----------------------------------------------------------------------------------------

            // Desarrollar un programa en C# que administre una
            // lista de productos mediante listas.
            // El programa permitirá:
            //  Agregar productos con nombre y precio solicitado al usuario.
            //  Mostrar la lista de productos.
            //  Actualizar un producto existente.
            //  Eliminar un producto de la lista.
            //  Salir del programa.

//                List<string> productos = new List<string>();
//                List<double> precios = new List<double>();
//                int opcion;

//                do
//                {
//                    Console.WriteLine("\n--- MENÚ DE PRODUCTOS ---");
//                    Console.WriteLine("1. Agregar producto");
//                    Console.WriteLine("2. Mostrar productos");
//                    Console.WriteLine("3. Actualizar producto");
//                    Console.WriteLine("4. Eliminar producto");
//                    Console.WriteLine("5. Salir");
//                    Console.Write("Elige una opción: ");
//                    opcion = int.Parse(Console.ReadLine());

//                    switch (opcion)
//                    {
//                        case 1:
//                            Console.Write("Nombre del producto: ");
//                            string nombre = Console.ReadLine();
//                            Console.Write("Precio del producto: ");
//                            double precio = double.Parse(Console.ReadLine());
//                            productos.Add(nombre);
//                            precios.Add(precio);
//                            Console.WriteLine("Producto agregado correctamente.");
//                            break;

//                        case 2:
//                            Console.WriteLine("\nLista de productos:");
//                            for (int i = 0; i < productos.Count; i++)
//                            {
//                                Console.WriteLine($"{i + 1}. {productos[i]} - ${precios[i]}");
//                            }
//                            break;

//                        case 3:
//                            Console.Write("Número del producto a actualizar: ");
//                            int num = int.Parse(Console.ReadLine()) - 1;
//                            if (num >= 0 && num < productos.Count)
//                            {
//                                Console.Write("Nuevo nombre: ");
//                                productos[num] = Console.ReadLine();
//                                Console.Write("Nuevo precio: ");
//                                precios[num] = double.Parse(Console.ReadLine());
//                                Console.WriteLine("Producto actualizado.");
//                            }
//                            else
//                            {
//                                Console.WriteLine("Número inválido.");
//                            }
//                            break;

//                        case 4:
//                            Console.Write("Número del producto a eliminar: ");
//                            int elim = int.Parse(Console.ReadLine()) - 1;
//                            if (elim >= 0 && elim < productos.Count)
//                            {
//                                productos.RemoveAt(elim);
//                                precios.RemoveAt(elim);
//                                Console.WriteLine("Producto eliminado.");
//                            }
//                            else
//                            {
//                                Console.WriteLine("Número inválido.");
//                            }
//                            break;

//                        case 5:
//                            Console.WriteLine("Saliendo del programa...");
//                            break;

//                        default:
//                            Console.WriteLine("Opción no válida.");
//                            break;
//                    }

//                } while (opcion != 5);
//            }
//        }
    }
    }
}
