using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace metodosExamen
{
    internal class Program
    {
        static void generarTablas()
        {
            Console.WriteLine("Ingrese el rango menor (tabla inicial) ");
            int Rango1 = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Ingrese el rango mayor (tabla final) ");
            int Rango2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el numero inicial multiplicador deseado");
            int multi1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el numero final multiplicador deseado");
            int multi2 = Convert.ToInt32(Console.ReadLine());

            for (int i = Rango1; i <= Rango2; i++)
            {
                Console.WriteLine("\n" + "Tabla del " + i + "\n");
                for (int j = multi1; j <= multi2; j++)
                {
                    Console.WriteLine(i + "X" + j + " = " + (i * j));
                }
            }

        }

        static void mostrarMenu()
        {
            Console.WriteLine("Menu de Hamburguesas");
            Console.WriteLine("1. Hamburguesa Tipo 1 - Precio: 10");
            Console.WriteLine("2. Hamburguesa Tipo 2 - Precio: 15");
        }

        static void calculoHamburguesas(int cantidad, int tipo)
        {
            if(tipo == 1)
            {
                float Precio1 = 10;
                float Total1 = Precio1 * cantidad; 
                float IVA1 = ((Total1 * 12) / 100); 
                float SubTotal1 = Total1 - IVA1;
                Console.WriteLine("IVA: " + IVA1);
                Console.WriteLine("El subtotal es: " + SubTotal1);
                Console.WriteLine("El total es: " + Total1);
                Console.ReadKey();

            }
            else
            {
                float Precio2 = 15;
                float Total2 = Precio2 * cantidad;
                float IVA2 = ((Total2 * 12) / 100);
                float SubTotal2 = Total2 - IVA2;
                Console.WriteLine("IVA: " + IVA2);
                Console.WriteLine("El subtotal es: " + SubTotal2);
                Console.WriteLine("El total es: " + Total2 + "\n");
                Console.ReadKey();
            }
        }

        static void simularReloj()
        {
            Console.WriteLine("Simulador de Hora" + "\n");
            for (int i = 00; i < 24; i++)
            {
                for (int j = 00; j < 60; j++)
                {
                    for (int k = 00; k < 60; k++)
                    {
                        Console.Clear();
                        Console.WriteLine(i + ":" + j + ":" + k);
                        System.Threading.Thread.Sleep(1000);
                        
                        /*if (k <= 9)
                        {
                            sg = "0" + k.ToString();
                            Console.WriteLine(i + ":" + j + ":" + sg);

                        }
                        else
                        {
                            Console.WriteLine(i + ":" + j + ":" + k);
                        }*/

                    }
                }
            }
        }

        static void menuPrincipal()
        {
            Console.WriteLine("Ingrese la opcion que desea" + "\n");
            Console.WriteLine("Opcion 1. Tablas " + "\n" + "Opcion 2. Venta Hamburguesas" + "\n" + "Opcion 3. Mostrar Hora" + "\n");
        }

        

        static void Main(string[] args)
        {
            
            

            int opcion = 0; 
            do {

                menuPrincipal();
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Generador tabla de multiplicar");
                        generarTablas(); 
                        break; 
                    case 2:
                        Console.WriteLine("Restaurante de Hamburguesas");
                        Console.WriteLine("Ingrese Cuantas Hamburguesas"); 
                        int cantidad = Convert.ToInt32(Console.ReadLine());
                        mostrarMenu(); 
                        Console.WriteLine("De que tipo desea comprar");
                        int tipo = Convert.ToInt32(Console.ReadLine());
                        calculoHamburguesas(cantidad, tipo);
                        break; 
                    case 3:
                        simularReloj();
                        break;
                    case 4:
                        break;
                }

            } while (opcion != 4);
        }
    }
}
