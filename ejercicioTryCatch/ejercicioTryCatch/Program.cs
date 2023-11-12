using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioTryCatch
{
    internal class Program
    {
        static void generarTablas()
        {
            try
            {
                int Rango1, Rango2, multi1, multi2;
                Console.WriteLine("Ingrese el rango menor (tabla inicial) ");
                Rango1 = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Ingrese el rango mayor (tabla final) ");
                Rango2 = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Ingrese el numero inicial multiplicador deseado");
                multi1 = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Ingrese el numero final multiplicador deseado");
                multi2 = Convert.ToInt16(Console.ReadLine());

                if(Rango1 > Rango2)
                {
                    Console.WriteLine("Rango 1 debe ser menos que Rango 2");
                }
                else
                {
                    for (int i = Rango1; i <= Rango2; i++)
                    {
                        Console.WriteLine("\n" + "Tabla del " + i + "\n");
                        for (int j = multi1; j <= multi2; j++)
                        {
                            Console.WriteLine(i + "X" + j + " = " + (i * j));
                        }
                    }
                }

                
            }
            catch (FormatException)
            {
                Console.WriteLine("Error los rangos o multiplicadores no son numeros");
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
            if (tipo == 1)
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
            else if (tipo == 2)
            {
                float Precio2 = 15;
                float Total2 = Precio2 * cantidad;
                float IVA2 = ((Total2 * 12) / 100);
                float SubTotal2 = Total2 - IVA2;
                Console.WriteLine("IVA: " + IVA2);
                Console.WriteLine("El subtotal es: " + SubTotal2);
                Console.WriteLine("El total es: " + Total2 + "\n");
                

            }
            else
            {
                Console.WriteLine("Error: tipo de combo no valido, ingrese de nuevo datos"); 
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


        static void ejemploUno_SinTryCatch()
        {
            Console.WriteLine("Ingrese un primer numero: "); 
            int n1 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo numero: ");
            int n2 = Convert.ToInt16(Console.ReadLine());
            int suma = n1 + n2;
            Console.WriteLine("La suma de " + n1 + " + " + n2 + " = " + suma);
            Console.ReadKey();
        }

        static void ejemploUno_TryCatch()
        {
            try
            {
                Console.WriteLine("Ingrese un primer numero: ");
                int n1 = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Ingrese el segundo numero: ");
                int n2 = Convert.ToInt16(Console.ReadLine());
                int suma = n1 + n2;
                Console.WriteLine("La suma de " + n1 + " + " + n2 + " = " + suma);
                Console.ReadKey();
            }
            catch (FormatException) //para controlar ingreso de numeros invalidos
            {
                Console.WriteLine("Error: el caracter ingresado no es valido, ingrese valor númerico entero" + "\n");
            }catch(OverflowException) // para controlar fuera de rango
            {
                Console.WriteLine("Error al hacer la suma, valor ingresado fuera de rango posible a calcular");
            }catch(Exception ex) //para controlar cualquier otro tipo de excepcion
            { 
                Console.WriteLine($"Error: {ex.Message}"); 
            }
        }


        static void ejemploDos_TryCatch()
        {
            Console.WriteLine("Ingrese un primer numero: ");
            string n1 = Console.ReadLine();
            Console.WriteLine("Ingrese el segundo numero: ");
            string n2 = Console.ReadLine();
            double numero1, numero2, suma;

            if (double.TryParse(n1, out numero1) && double.TryParse(n2, out numero2)) {
                suma = numero1 +  numero2;
                Console.WriteLine($"La suma de {numero1} + {numero2} es = {suma}");
            }
            else
            {
                Console.WriteLine("Error: Datos ingresados no validos, por ingrese datos validos"); 
            }

            
        }

        static void Main(string[] args)
        {



            int opcion = 0;
            do
            {

                menuPrincipal();
                try
                {
                    opcion = Convert.ToInt16(Console.ReadLine());
                }catch(FormatException) { Console.WriteLine("Error: opcion no valida, ingrese una opcion del menu"); }
                
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Generador tabla de multiplicar");
                        generarTablas();
                        break;
                    case 2:
                        int cantidad,  tipo =0;
                        string ctd, tpo;
                        Console.WriteLine("Restaurante de Hamburguesas" + "\n");
                        mostrarMenu();
                        do
                        {
                            Console.WriteLine("Ingrese Cuantas Hamburguesas" + "\n");
                            ctd = Console.ReadLine();
                            Console.WriteLine("Seleccione que tipo desea comprar");
                            tpo = Console.ReadLine();

                            if (int.TryParse(ctd, out cantidad) && int.TryParse(tpo, out tipo))
                            {
                                calculoHamburguesas(cantidad, tipo);
                            }
                            else
                            {
                                Console.WriteLine($"Error: La solicitud de compra es incorrecta, verifique los datos. ");
                                Console.WriteLine($"Cantidad: {ctd} y Tipo seleccionado: {tpo} " + "\n");

                            }
                        } while (tipo >= 3 || int.TryParse(tpo, out tipo) == false);

                        opcion = 0;
                        Console.ReadKey();

                        break;
                    case 3:
                        ejemploDos_TryCatch();
                        //ejemploUno_TryCatch();
                        //ejemploUno_SinTryCatch();
                        //simularReloj();
                        break;
                    case 4:
                        break;
                }

            } while (opcion != 4);
        }
    }
}

