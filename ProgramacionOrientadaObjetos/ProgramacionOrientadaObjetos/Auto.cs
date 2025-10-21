using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionOrientadaObjetos
{
    //Clase
    internal class Auto
    {
    public string marca { get; set; }
    public string modelo { get; set; }
    public int anio { get; set; }

    //Constructor
    public Auto(string marca, string modelo, int anio)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.anio = anio;
    }

    //Objeto
    public void MostrarInfo()
        {
            Console.WriteLine($"La marca de este carro es: {marca}, su modelo es: {modelo} y es del año: {anio}.");
        }
    }
}
