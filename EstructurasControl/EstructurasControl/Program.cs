using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Ingrese la edad: ");
            int edad;
            edad = Convert.ToInt32(Console.ReadLine());

            /*if (edad >= 18)
            {
                Console.WriteLine("Ese mayor de edad");
            } else if (edad  <= 0)
            {
                Console.WriteLine("edad no valida"); 
            }
            else
            {
                Console.WriteLine("Es menor de edad"); 
            }*/


            /* HACER UN IF ANIDADO*/


            /*int num = 0; 
            while (num <= 100) {
            Console.WriteLine("Iteracion: " + (num+1 ) + " Valor: " + num);
                num++;
            }*/

            /*Tabla de multiplicar

            Console.WriteLine("Ingrese tabla inicial: ");
            int multi = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese tabla final: ");
            int multi2 = Convert.ToInt16(Console.ReadLine());

            for (int i = multi; i <=  multi2;  i++)
            {
                Console.WriteLine("Tabla numero: "+ i);
                for(int j = 1; j <= 10; j++)
                {
                    Console.WriteLine(i+"x"+j+"="+i*j);
                }
            }
            */

            /* TABLA DE MULTIPLICAR DEL 1 AL 10
            for(int i = 1; i <= 10; i++) {
                Console.WriteLine("Tabla del: "); 
                for(int j = 1; j <= 10; j++)
                {
                    Console.WriteLine(i*j);
                }
            }
            Console.ReadKey();*/

            /* TABLA DE MULTIPLICAR NUMERO ESPECÍFICO
             
            Console.WriteLine("Ingrese la tabla que desea generar");
            int numero_tabla = 0;
            numero_tabla = Convert.ToInt16(Console.ReadLine()); 
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i+"x"+ numero_tabla + " = "+ (i * numero_tabla));
            }*/

            /* CALCULO DE NUMERO FACTORIAL
            int rfactorial = 1;
            int num_factorial = 0; 

            Boolean salir = false;
            do
            {
                
                Console.WriteLine("Que factorial desea sacar: ");
                num_factorial = Convert.ToInt32(Console.ReadLine());
                for (int i = num_factorial; i >= 1; i--)
                {
                    rfactorial = rfactorial * i;
                }
                Console.WriteLine("Factorial de" + num_factorial + " es:  " + rfactorial + "\n");
                rfactorial = 1; 
                Console.WriteLine("Desea calcular otro factorial: true = salir, false = calcular" + "\n"); 
                salir = Convert.ToBoolean(Console.ReadLine());

            } while (salir == false);*/
        }
    }
}
