using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _9490_21_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0; 
            int rango1 = 0;
            int rango2 = 0;
            int multi1 = 0; 
            int multi2 = 0;

            
            do
            {
                Console.WriteLine("\n" + "Ingrese la Opcion" + "\n");
                Console.WriteLine("Opcion 1. Tablas " + "\n" + "Opcion 2. Calculo IVA" + "\n" + "Opcion 3. Mostrar Hora" + "\n");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion) {
                    case 1:
                        Console.WriteLine("Tablas" + "\n");
                        Console.WriteLine("Ingrese el rango menor (tabla inicial) ");
                        rango1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el rango mayor (tabla final) ");
                        rango2 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese el numero inicial multiplicador deseado");
                        multi1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el numero final multiplicador deseado");
                        multi2 = Convert.ToInt32(Console.ReadLine());

                        for (int i = rango1; i <= rango2; i++)
                        {
                            Console.WriteLine("\n" + "Tabla del " + i + "\n");
                            for (int j = multi1; j <= multi2; j++)
                            {
                                Console.WriteLine(i + "X" + j + " = " + (i * j));
                            }
                        }

                        break;

                    case 2:
                        opcion = 0;
                        Console.WriteLine("Venta Hamburguesas" + "\n");
                        double IVA = 0.12;
                        double sub_total = 0.00 % 2f;
                        double total = 0.00;

                        Console.WriteLine("Ingrese el precio de hamburguesa: " + "\n");
                        sub_total = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ingrese el precio de las papas: " + "\n");

                        sub_total = Convert.ToDouble(Console.ReadLine()) + sub_total;

                        Console.WriteLine("\n "+"Precio sin IVA : " + sub_total + "\n");

                        double detalle_IVA = sub_total * IVA;
                        total = detalle_IVA + sub_total;
                        Console.WriteLine("************************" + "\n");
                        Console.WriteLine("Detalle Compra " + "\n" +
                            "Sub total de Compra: " + sub_total + "\n" +
                            "IVA de la Compra: " + detalle_IVA + "\n" +
                            "Precio con IVA: " + total + "\n");
                        Console.WriteLine("************************" + "\n");
                        break;

                    case 3:
                        opcion = 0;
                        Console.WriteLine("Simulador de Hora" + "\n");
                        String sg = "";
                        for(int i = 00; i < 24; i++){
                            for(int j = 00; j < 60; j++){
                                for(int k = 00; k < 60; k++){
                                    Console.Clear();
                                    Console.WriteLine(i + ":" + j + ":" + k);
                                    for(int w = 0; w < 1000000000; w++)
                                    {

                                    }
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
                        break;
                    case 4: 
                        break;
                }
                
            } while (opcion != 4);
            
        }
        
        
    }
}
