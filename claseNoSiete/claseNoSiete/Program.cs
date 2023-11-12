using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace claseNoSiete
{
    internal class Program
    {
        //Ejercicio para seleccionar rango de numeros y multiplicadores y generar matriz de resultados. 
        static void generarTablasMatriz()
        {
            Console.WriteLine("Ingrese el rango menor (tabla inicial) ");
            int Rango1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el rango mayor (tabla final) ");
            int Rango2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el numero inicial multiplicador deseado");
            int multi1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el numero final multiplicador deseado");
            int multi2 = Convert.ToInt32(Console.ReadLine());

                int fila = (Rango2 - Rango1 + 1);
                int columna = (multi2 - multi1 + 1);
                int[,] resultados = new int[fila, columna];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < columna; j++)
                    {
                        resultados[i, j] = (Rango1 + i) * (multi1 + j);
                    }
                }
                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < columna; j++)
                    {
                        Console.Write(resultados[i, j] + ",");
                    }
                    Console.WriteLine();
                }
            }

        //Ejercicio para generar tablas especificas y  multiplicadores específicos con vectores
        static void generarTablas()
        {
            Console.WriteLine("Ingrese el rango menor (tabla inicial) ");
            int Rango1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el rango mayor (tabla final) ");
            int Rango2 = Convert.ToInt32(Console.ReadLine());
            int x = (Rango2 - Rango1 + 1);
            Console.WriteLine("Ingrese el numero inicial multiplicador deseado");
            int multi1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el numero final multiplicador deseado");
            int multi2 = Convert.ToInt32(Console.ReadLine());
            int y = multi2 - multi1 + 1;

            int[] xTablas = new int[x];
            int[] xMultiplicador = new int[y];
            int[] resultados = new int[(x*y)];


            for (int k = 0; k < x; k++)
            {
              xTablas[k] = (Rango1 + k);
            }

            for (int k = 0; k < y; k++)
            {
                xMultiplicador[k] = (multi1 + k);
            }

            for (int k = 0; k < x; k++)
            {   
                for(int j = 0; j < y; j++)
                {
                    resultados[(k*y) + j] = xTablas[k] * (xMultiplicador[j]); 
                }
            }

            for(int w = 0; w < resultados.Length; w++)
            {
                Console.Write(resultados[w] + " , ");
            }
        }    
        


        //Generar tablas del 1 al 10 y guardar en matriz
        static void rellenarMatriz()
        {
            int[,] resultados = new int[10,10]; 
            for(int i = 0; i < resultados.GetLength(0); i++)
            {
                for(int j = 0; j < resultados.GetLength(1); j++)
                {
                    resultados[i, j] = (i+1)*(j+1); 
                }
            }

            for(int i = 0; i < resultados.GetLength(0); i++)
            {
                Console.WriteLine("Tabla del: " + (i+1)); 
                for(int j = 0; j < resultados.GetLength(1); j++) {
                 
                    Console.WriteLine(resultados[i,j]);
                }
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            /*int[] numeros = new int[5];
            numeros[0] = 10;
            numeros[1] = 20;
            numeros[2] = 30;
            numeros[3] = 40;
            numeros[4] = 50;
            Console.WriteLine("Elemento en la index 0: " + numeros[0]);
            Console.WriteLine("Elemento en la index 2: " + numeros[2]);
            //Console.ReadKey();
            Console.WriteLine("Todo los elementos del vector: " + "\n"); 
            for(int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine("Elemento en la posicion: " + i +": " +numeros[i]);
            }*/

            //generarTablasMatriz();
            generarTablas();
            //rellenarMatriz();
            Console.ReadKey();



        }
    }
}
