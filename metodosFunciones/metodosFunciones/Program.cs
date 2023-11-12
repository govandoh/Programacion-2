using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodosFunciones
{
    internal class Program
    {

        static void Saludos(String Nombre)
        {
            Console.WriteLine("Hola Mundo " + Nombre + ", Gusto en saludarte");
            //String saludo = "Hola Mundo" + Nombre + " Gusto en saludarte";
            //return saludo;
        }

        static void Main(string[] args)
        {
            Saludos("Juan");
            Console.ReadKey();
        }
        
    }
}
