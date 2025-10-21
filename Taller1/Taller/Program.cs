using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ejercicio1: Un estudiante realiza un préstamo a un plazo de 5 años, donde la tasa fija de interés es 
            ////del 5 % anual, se debe solicitar el monto del préstamo y se desea calcular la siguiente
            ////información.
            ////• Cuanto dinero se ha pagado de intereses en un año. 
            ////• Cuanto dinero se ha pagado de intereses en el tercer trimestre del año.
            ////• Cuanto dinero se ha pagado de intereses en el primer mes.
            ////• Cuanto dinero se paga en total del préstamo solicitado incluyendo intereses.


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

            //ejercicio2: Desarrollar un algoritmo que permita generar la colilla de pago de los empleados de una 
            //            empresa.La colilla debe mostrar:
            //● El Salario del Empleado 
            //● El Valor de Ahorro mensual programado.
            //● La suma a deducir por aporte a la Salud(EPS) 12,5 %
            //● La suma a deducir por aporte al Fondo de Pensiones 16 %
            //● Total a Recibir
            //● Toda la información que debe proveer el usuario del programa es el Salario del
            //Empleado y el Valor de Ahorro mensual programado. El programa debe calcular y
            //devolver el resto de los datos.4


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


            //Ejercicio3: . PROGRAMA AGENDA
            //crearé una clase llamada "Persona" con las propiedades "Nombre", "Edad" y "Género (el 
            //usuario deberá seleccionar
            //F o M) telefono". También crearé un constructor para la clase "Persona" y métodos: para 
            //editar la información del usuario, agregar un nuevo usuario, imprimir los detalles de la
            //persona y otro para calcular la edad en días.El programa solicitará al usuario que ingrese los
            //detalles de la persona y luego le permitirá elegir entre dos opciones: imprimir los detalles de
            //la persona o calcular la edad en días.
            //solicita al usuario que ingrese los detalles de la persona(nombre, edad y género) y luego
            //crea un objeto "Persona" con esos detalles.Luego, le presenta al usuario un menú de
            //opciones que le permite imprimir los detalles de la persona, calcular la edad en días o salir
            //del programa.Si el usuario selecciona la opción de imprimir detalles de la persona, el
            //programa llama al método "ImprimirDetalles" de la clase "Persona", que imprime los
            //detalles de la persona en la consola. Si el usuario selecciona la opción de calcular edad en
            //días, el programa llama al método "CalcularEdadEnDias" de la clase "Persona", que calcula la
            //edad en días y la imprime en la consola.

            //Console.Write("Nombre: ");
            //string nombre = Console.ReadLine();
            //Console.Write("Edad: ");
            //int edad = int.Parse(Console.ReadLine());
            //Console.Write("Género (F/M): ");
            //string genero = Console.ReadLine();
            //Console.Write("Teléfono: ");
            //string telefono = Console.ReadLine();

            //Persona persona = new Persona(nombre, edad, genero, telefono);

            //int opcion;
            //do
            //{
            //    Console.WriteLine("\n1. Imprimir Detalles\n2. Calcular Edad en Días\n3. Salir");
            //    opcion = int.Parse(Console.ReadLine());
            //    if (opcion == 1) persona.ImprimirDetalles();
            //    else if (opcion == 2) persona.CalcularEdadEnDias();
            //} while (opcion != 3);


            //ejercicio4: ADMINISTRACIÓN DE UNA BIBLIOTECA.
            //Crear la clase "Libro" tiene los atributos "Titulo", "Autor", "Editorial" y "AnioPublicacion", 
            //que se definen en el constructor de la clase.La clase "Biblioteca" contiene una lista de
            //objetos "Libro", que se pueden agregar mediante el método "AgregarLibro" y listar mediante
            //el método "ListarLibros".En el método, un método para buscar el libro por su nombre. 
            //"Main", se muestra un menú de opciones.


            //Biblioteca biblio = new Biblioteca();
            //int opcion;
            //do
            //{
            //    Console.WriteLine("\n1. Agregar Libro\n2. Listar Libros\n3. Buscar Libro\n4. Salir");
            //    opcion = int.Parse(Console.ReadLine());
            //    if (opcion == 1)
            //    {
            //        Console.Write("Título: "); string t = Console.ReadLine();
            //        Console.Write("Autor: "); string a = Console.ReadLine();
            //        Console.Write("Editorial: "); string e = Console.ReadLine();
            //        Console.Write("Año: "); int an = int.Parse(Console.ReadLine());
            //        biblio.AgregarLibro(new Libro(t, a, e, an));
            //    }
            //    else if (opcion == 2) biblio.ListarLibros();
            //    else if (opcion == 3)
            //    {
            //        Console.Write("Ingrese título a buscar: ");
            //        biblio.BuscarLibro(Console.ReadLine());
            //    }
            //} while (opcion != 4);

            //Ejercicio5: Una universidad requiere analizar el proceso de matrícula para el tercer período 
            //académico del 2020 de cada uno de los estudiantes. La universidad consta de cinco(5)
            //programas académicos. Cada programa académico tiene un número de créditos
            //asociados.El valor de cada crédito académico es de $200.000.


        }
    }
}
