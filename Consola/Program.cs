
using System;

namespace Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            Web.Models.Procesos procesos = new Web.Models.Procesos(); 
            Console.WriteLine(procesos.CrearPalabra());
        }
    }
}
