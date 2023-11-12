using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static tareaSecuenciales.Program;

namespace tareaSecuenciales
{
    internal class Program
    {
        public class AuditFile
        {
            public string FileName = "archivo_Tarea.txt";
            private int _linea;
            public List<string> ListaArchivo;
            public List<string> ListaModificar;

            public int Linea
            {
                get { return _linea; }
                set { _linea = value; }
            }

            public void setLinea(int linea)
            {
                _linea = linea;
            }

            public int getLinea()
            {
                return _linea;
            }
            
            
            public void GenerarMenu()
            {
                Console.WriteLine("\n" + "Menu Archivo Secuencial" + "\n");
                Console.WriteLine("Opcion 1. Grabar Informacion " + "\n" + "Opcion 2. Leer Archivo" + "\n" +
                    "Opcion 3. Eliminar linea del archivo" + "\n" + "Opcion 4. Modificar linea del archivo" + "\n" + "Opcion 5. Salir." + "\n");
            }

            public int SolicitarOpcion()
            {
                int opcion = 0;

                do
                {
                    try
                    {
                        Console.WriteLine("Seleccione una opción del menu");
                        opcion = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ingreso por teclado inválido");
                        Console.ResetColor();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (opcion <= 0);

                return opcion;
            }

            public void EscribirLinea()
            {
                Console.WriteLine("Ingrese el texto que desea grabar en la linea" + "\n");
                string linea = Console.ReadLine();
                using (StreamWriter write = new StreamWriter(FileName, true))
                {
                    write.WriteLine(linea);
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine("Linea grabada" + "\n");
                    Console.ResetColor(); 
                }
            }

            public void LeerArchivo()
            {
                if (File.Exists(FileName))
                {
                    using (StreamReader read = new StreamReader(FileName))
                    {
                        int cont = 1;
                        string texto;
                        while ((texto = read.ReadLine()) != null)
                        {
                            Console.WriteLine($"Linea {cont}: {texto}");
                            cont++;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("El archivo no existe");
                }
            }

            public int SolicitarLinea()
            {
                try
                {
                    Console.WriteLine("Ingrese el numero de línea para modificar/borrar");
                    setLinea(Convert.ToInt16(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error con la linea ingresada, ingrese linea valida" + "\n");
                    Console.ResetColor();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }


                return getLinea();
            }

            public void ejecutarDelete()
            {
                ListaArchivo = new List<string>();
                Linea = SolicitarLinea();
                if (File.Exists(FileName))
                {

                    using (StreamReader reader = new StreamReader(FileName))
                    {
                        string lineaLeida;
                        while ((lineaLeida = reader.ReadLine()) != null)
                        {
                            ListaArchivo.Add(lineaLeida);
                        }
                    }

                    EliminarLinea();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Archivo no existe" + "\n");
                    Console.ResetColor();
                }
            }

            public void EliminarLinea()
            {
                if (Linea >= 1 && Linea <= ListaArchivo.Count)
                {
                    ListaArchivo.RemoveAt(Linea - 1);
                    ReescribirListaEliminar();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Linea {Linea}, no valida, fuera de rango" + "\n");
                    Console.ResetColor();
                }
            }

            public void ReescribirListaEliminar()
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    foreach (string linea in ListaArchivo)
                    {
                        writer.WriteLine(linea);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Linea No. {Linea}, eliminada del archivo");
                    Console.ResetColor();
                }
            }


            public void EjecutarModificar()
            {
                ListaModificar = new List<string>(); 
                Linea = SolicitarLinea();

                if(File.Exists(FileName))
                {
                    using (StreamReader reader = new StreamReader(FileName))
                    {
                        string linea;
                        while ((linea = reader.ReadLine()) != null)
                        {
                            ListaModificar.Add(linea);
                        }
                    }
                    ModificarLinea(); 
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Archivo no existe"+"\n");
                    Console.ResetColor();
                }
                

            }

            public void ReescribirListaModificar()
            {   
                using(StreamWriter writer = new StreamWriter(FileName))
                {
                    string modificacion = " ";
                    Console.WriteLine($"Ingrese el texto para modificar la linea: {Linea}");
                    modificacion = Console.ReadLine();
                    ListaModificar[Linea - 1] = modificacion;
                    foreach (string linea in ListaModificar)
                    {
                        writer.WriteLine(linea);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Linea {Linea} Modificada en el archivo" + "\n");
                    Console.ResetColor();
                } 
                
            }

            public void ModificarLinea()
            {
                if(Linea >= 1 && Linea <= ListaModificar.Count)
                {
                    ReescribirListaModificar(); 
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Linea {Linea}, fuera de rango" + "\n");
                    Console.ResetColor(); 
                }
            }



        }
        static void Main(string[] args)
        {
            AuditFile auditFile = new AuditFile();
            int opcion;
            do
            {
                auditFile.GenerarMenu();
                opcion = auditFile.SolicitarOpcion();
                
                switch (opcion)
                {
                    case 1:
                        auditFile.EscribirLinea();
                        break;
                    case 2:
                        auditFile.LeerArchivo();
                        break;
                    case 3:
                        auditFile.ejecutarDelete();
                        break;
                    case 4:
                        auditFile.EjecutarModificar();
                        break; 
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion no valida, ingrese una opcion del menu");
                        Console.ResetColor();   
                        break;
                }
            } while (opcion != 5);

        }
    }
}
