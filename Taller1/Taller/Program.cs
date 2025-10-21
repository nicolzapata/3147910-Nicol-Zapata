using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            //Universidad universidad = new Universidad();

            //Console.Write("¿Cuántos estudiantes desea matricular?: ");
            //int cantidad = int.Parse(Console.ReadLine());

            //for (int i = 0; i < cantidad; i++)
            //{
            //    Console.WriteLine($"\nEstudiante {i + 1}:");
            //    universidad.MatricularEstudiante();
            //}

            //universidad.MostrarResultados();


            //Ejercicio6:La empresa de tecnología “COMPUTRONIC”, es una empresa líder en venta y
            //distribución de equipos tecnológicos en la ciudad de Bogotá y cuenta en su única sede
            //con un N cantidad de empleados quienes realizanN ventas durante el día. La empresa
            //requiere identificar cuántas de las ventas fueron menores o iguales a $300.000,
            //cuántas ventas fueron mayores a $
            //300.000 y menores a $800.000 y cuántas fueron mayores o iguales a
            //$800.000 por cada empleado.

            //Console.Write("Ingrese el número de empleados: ");
            //int n = int.Parse(Console.ReadLine());

            //double pagoBase = 500000;

            //for (int i = 1; i <= n; i++)
            //{
            //    Console.WriteLine($"\nEmpleado {i}:");
            //    Console.Write("Ingrese cantidad de ventas realizadas: ");
            //    int numVentas = int.Parse(Console.ReadLine());

            //    double totalVentas = 0;
            //    int menores300 = 0, entre300y800 = 0, mayores800 = 0;

            //    for (int j = 1; j <= numVentas; j++)
            //    {
            //        Console.Write($"Valor de la venta {j}: ");
            //        double venta = double.Parse(Console.ReadLine());
            //        totalVentas += venta;

            //        if (venta <= 300000) menores300++;
            //        else if (venta < 800000) entre300y800++;
            //        else mayores800++;
            //    }

            //    double bonificacion = 0;
            //    if (totalVentas >= 800000) bonificacion = totalVentas * 0.10;
            //    else if (totalVentas >= 400001 && totalVentas <= 800000) bonificacion = totalVentas * 0.05;
            //    else if (totalVentas >= 400000) bonificacion = totalVentas * 0.03;

            //    Console.WriteLine("\n--- RESUMEN DEL EMPLEADO ---");
            //    Console.WriteLine($"Ventas <= 300.000: {menores300}");
            //    Console.WriteLine($"Ventas entre 300.001 y 800.000: {entre300y800}");
            //    Console.WriteLine($"Ventas >= 800.000: {mayores800}");
            //    Console.WriteLine($"Monto total vendido: ${totalVentas}");
            //    Console.WriteLine($"Bonificación: ${bonificacion}");
            //    Console.WriteLine($"Pago total (básico + bonificación): ${pagoBase + bonificacion}");
            //}


            //Ejercicio7: Una oficina de seguros ha reunido datos concernientes a todos los accidentes de
            //tránsito ocurridos en el área metropolitana de Bogotá en el último año.Por cada
            //conductor involucrado en un accidente se toman los siguientes datos: año de
            //nacimiento, sexo(1: Femenino, 2: Masculino) y registro del carro(1: Bogotá, 2: Otras
            //ciudades). Desarrollar una solución básica de programación que calcule:
            //• El porcentaje de conductores menores de 30 años.
            //• Porcentaje de conductores del sexo masculino y femenino.
            //• Porcentaje de conductores masculinos con edades entre 12 y 30 años.
            //• Porcentaje de conductores cuyos carros están registradosfuera de Bogotá.


            //Console.Write("Ingrese cantidad de conductores: ");
            //int n = int.Parse(Console.ReadLine());

            //int menores30 = 0, masculinos = 0, femeninos = 0, masc12a30 = 0, fueraBogota = 0;

            //for (int i = 1; i <= n; i++)
            //{
            //    Console.WriteLine($"\nConductor {i}:");
            //    Console.Write("Año de nacimiento: ");
            //    int anio = int.Parse(Console.ReadLine());
            //    int edad = 2025 - anio;

            //    Console.Write("Sexo (1: Femenino, 2: Masculino): ");
            //    int sexo = int.Parse(Console.ReadLine());

            //    Console.Write("Registro del carro (1: Bogotá, 2: Otras ciudades): ");
            //    int registro = int.Parse(Console.ReadLine());

            //    if (edad < 30) menores30++;
            //    if (sexo == 1) femeninos++;
            //    else
            //    {
            //        masculinos++;
            //        if (edad >= 12 && edad <= 30) masc12a30++;
            //    }
            //    if (registro == 2) fueraBogota++;
            //}

            //Console.WriteLine("\n--- RESULTADOS ---");
            //Console.WriteLine($"Porcentaje menores de 30: {(double)menores30 / n * 100}%");
            //Console.WriteLine($"Porcentaje masculinos: {(double)masculinos / n * 100}%");
            //Console.WriteLine($"Porcentaje femeninos: {(double)femeninos / n * 100}%");
            //Console.WriteLine($"Porcentaje masculinos entre 12 y 30: {(double)masc12a30 / n * 100}%");
            //Console.WriteLine($"Porcentaje con registro fuera de Bogotá: {(double)fueraBogota / n * 100}%");



            //Ejercicio8: La empresa Tik Tok desea otorgar una bonificación a una cantidad N de sus
            //empleados, y para ello desea registrar la fecha de nacimientode cada uno de ellos en
            //su sistema de información. La bonificación se la dará sólo a los empleados mayores de
            //18 años y menores de 50 años y será un bonode $150.000 en el mes de su cumpleaños.
            //Con estos empleados se debe:
            //● Sacar el promedio de las edades.
            //● Publicar una lista desglosada por meses con el número total de empleadosque
            //cumplen años en cada mes, y el dinero total pagado en bonos.
            //Finalmente, se debe saber el total de dinero que debe tener la empresa Tik Tok
            //por concepto de bonificación.

            //Console.Write("Ingrese número de empleados: ");
            //int n = int.Parse(Console.ReadLine());

            //int[] empleadosPorMes = new int[12];
            //int totalBonos = 0, totalEdad = 0;

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"\nEmpleado {i + 1}:");
            //    Console.Write("Año de nacimiento: ");
            //    int anio = int.Parse(Console.ReadLine());
            //    Console.Write("Mes de nacimiento (1-12): ");
            //    int mes = int.Parse(Console.ReadLine());

            //    int edad = 2025 - anio;
            //    totalEdad += edad;

            //    if (edad >= 18 && edad < 50)
            //    {
            //        empleadosPorMes[mes - 1]++;
            //        totalBonos += 150000;
            //    }
            //}

            //double promedioEdad = (double)totalEdad / n;

            //Console.WriteLine("\n--- BONIFICACIONES ---");
            //for (int i = 0; i < 12; i++)
            //    if (empleadosPorMes[i] > 0)
            //        Console.WriteLine($"Mes {i + 1}: {empleadosPorMes[i]} empleados - ${empleadosPorMes[i] * 150000} en bonos");

            //Console.WriteLine($"\nPromedio de edad: {promedioEdad}");
            //Console.WriteLine($"Total dinero en bonos: ${totalBonos}");


            //ejercicio9: Una central de distribución de químicos distribuye Alcohol hacia diferentes almacenes
            //sucursales.Disponen de un muelle de carga a donde van llegando tanques de alcohol
            //de entre 3000 y 9000 litros, con pesos variables en función de las circunstancias de la
            //producción.La empresa dispone de una flota de camiones con capacidades de carga
            //de entre 18000y 28000 litros.
            //Se pretende establecer un protocolo consistente en cargar 20 camiones diarios. Cada
            //camión se quiere cargar como máximo a su límite de capacidaddebiendo partir si con la
            //siguiente saca en la línea de producción se fuera a exceder su capacidad.

            //La empresa quiere desarrollar una solución básica de programación que le pida al
            //operario encargado de carga la capacidad del camión y el peso de lassacas, indicándole
            //si debe cargar los tanques de alcohol o despachar el camión para comenzar a cargar
            //otro.


                //Console.WriteLine("Protocolo de carga de camiones\n");

                //for (int i = 1; i <= 20; i++)
                //{
                //    Console.Write($"\nCamión {i} - Capacidad máxima (litros): ");
                //    double capacidad = double.Parse(Console.ReadLine());

                //    double cargaActual = 0;
                //    string continuar;

                //    do
                //    {
                //        Console.Write("Ingrese cantidad de litros del tanque a cargar: ");
                //        double saca = double.Parse(Console.ReadLine());

                //        if (cargaActual + saca > capacidad)
                //        {
                //            Console.WriteLine("⚠️ Se excede la capacidad. Debe despachar el camión.");
                //            break;
                //        }

                //        cargaActual += saca;
                //        Console.Write("¿Desea cargar otro tanque? (s/n): ");
                //        continuar = Console.ReadLine().ToLower();

                //    } while (continuar == "s");

                //    Console.WriteLine($"Camión {i} despachado con {cargaActual} litros.\n");
                //}

                //Console.WriteLine("✅ Se completó la carga de 20 camiones.");
            }
        }
    }
