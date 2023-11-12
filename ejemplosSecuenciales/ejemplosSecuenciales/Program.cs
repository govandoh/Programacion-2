using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplosSecuenciales
{
    internal class Program
    {
        class Secuenciales
        {
            public string NombreArchivo = "Archivo.txt";
            public void GrabarLinea(string NombreArchivo)
            {
                Console.Write("Ingrese la línea que desea grabar en el archivo: ");
                string Linea = Console.ReadLine();
                //el true significa que lo abre en forma append, si el archivo ya existe se posiciona al final
                //del archivo y escribira al final del archivo
                using (StreamWriter escritor = new StreamWriter(NombreArchivo, true))
                {
                    escritor.WriteLine(Linea);
                    Console.WriteLine("Línea grabada en el archivo.");
                }
            }

            public void LeerArchivo(string NombreArchivo)
            {
                if (File.Exists(NombreArchivo))
                {
                    using (StreamReader Lector =
                    new StreamReader(NombreArchivo))
                    {
                        Console.WriteLine("Contenido del archivo:");
                        string contenido;
                        while ((contenido =
                        Lector.ReadLine()) != null)
                        {
                            Console.WriteLine(contenido);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El archivo no existe.");
                }
            }


            public void EliminarLinea(string NombreArchivo)
            {
                Console.Write("Ingrese el número de línea que desea eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int numeroLinea) && numeroLinea >= 1)
                {
                    List<string> Lineas = new List<string>();
                    if (File.Exists(NombreArchivo))
                    {
                        using (StreamReader Lector = new StreamReader(NombreArchivo))
                        {
                            string Linea;
                            while ((Linea = Lector.ReadLine()) != null)
                            {
                                Lineas.Add(Linea);
                            }
                        }
                        if (numeroLinea >= 1 && numeroLinea <= Lineas.Count)
                        {
                            Lineas.RemoveAt(numeroLinea - 1);
                            using (StreamWriter escritor = new StreamWriter(NombreArchivo))
                            {
                                foreach (string Linea in Lineas)
                                {
                                    escritor.WriteLine(Linea);
                                }
                            }
                            Console.WriteLine("Línea eliminada del archivo.");
                        }


                        else
                        {
                            Console.WriteLine("Número de línea fuera de rango.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El archivo no existe.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida para el número de línea.");
                }
            }

            public void menu()
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Grabar línea en el archivo");
                Console.WriteLine("2. Leer el archivo");
                Console.WriteLine("3. Eliminar línea del archivo");
                Console.WriteLine("4. Modificar línea del archivo");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese la opción deseada: ");
            }

            public void modificarLinea(string NombreArchivo)
            {
                int numeroLinea;
                List<string> LineasModificar = new List<string>();
                Console.WriteLine($"Ingrese el numero de linea que desea modificar");
                if (int.TryParse(Console.ReadLine(), out numeroLinea) && numeroLinea >= 1)
                {
                    if (File.Exists(NombreArchivo))
                    {
                        using (StreamReader lector = new StreamReader(NombreArchivo))
                        {
                            string Linea;
                            while ((Linea = lector.ReadLine()) != null)
                            {
                                LineasModificar.Add(Linea);
                            }
                        }

                        if (numeroLinea >= 1 && numeroLinea <= LineasModificar.Count)
                        {
                            using (StreamWriter escritor = new StreamWriter(NombreArchivo))
                            {
                                string modificacion = " ";
                                Console.WriteLine($"Ingrese el texto nuevo:");
                                modificacion = Console.ReadLine();
                                LineasModificar[numeroLinea - 1] = modificacion;
                                foreach (string Linea in LineasModificar)
                                {

                                    escritor.WriteLine(Linea);
                                }
                                Console.WriteLine("Línea modificada del archivo.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Número de línea fuera de rango.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El archivo no existe.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida para el número de línea.");
                }


            }


        }
        static void Main(string[] args)
        {
            //string NombreArchivo = "Archivo.txt";
            Secuenciales controlArchivo = new Secuenciales();
            int opcion = 0;

            do
            {
                controlArchivo.menu();
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida.Intente de nuevo." + "\n");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        controlArchivo.GrabarLinea(controlArchivo.NombreArchivo);
                        break;
                    case 2:
                        controlArchivo.LeerArchivo(controlArchivo.NombreArchivo);
                        break;
                    case 3:
                        controlArchivo.EliminarLinea(controlArchivo.NombreArchivo);
                        break;
                    case 4:
                        controlArchivo.modificarLinea(controlArchivo.NombreArchivo);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo." + "\n");
                        break;
                }
            } while (opcion != 5);
        }
    }
}
