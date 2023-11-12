using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratorio10_07
{
    internal class Program
    {

        class ControlesJuego
        {
            public char[,] tableroJuego = new char[3, 3];
            public string HistorialJuego = "historial_partidasTotito.txt";

            

            public void menuPrincipal()
            {
                Console.WriteLine("\n" + "Menu Laboratorio" + "\n");
                Console.WriteLine("Opcion 1. Jugar Totito " + "\n" + "Opcion 2. Historial de Juegos" + "\n" +
                    "Opcion 3. Salir." + "\n");
            }

            public int SolicitarOpcionMenu()
            {
                int opcion = 0;

                do
                {
                    try
                    {
                        Console.WriteLine("Ingrese la opcion del menú que desea ejecutar");
                        opcion = Convert.ToInt16(Console.ReadLine());
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

            public void InicializarTablero()
            {
                for (int i = 0; i < tableroJuego.GetLength(0); i++)
                {
                    for (int j = 0; j < tableroJuego.GetLength(1); j++)
                    {

                        tableroJuego[i, j] = '-';
                    }
                }
            }

            public void MostrarTablero()
            {
                int posicion = 1;
                Console.WriteLine("\n" + "Posiciones actuales de tablero, puede ingresar X o O en posiciones no ocupadas");
                for (int i = 0; i < tableroJuego.GetLength(0);  i++)
                {
                    for (int j = 0; j < tableroJuego.GetLength(1); j++)
                    {
                        if (tableroJuego[i, j] == 'X' || tableroJuego[i, j] == 'O')
                        {
                            Console.Write(" " + tableroJuego[i, j]);
                        }
                        else
                        {
                            Console.Write(" " + posicion);
                        }
                        posicion++;
                    }
                    Console.WriteLine("\n");
                }
            }

            public void juegoActual()
            {
                Console.WriteLine();
                Console.WriteLine($"Este es el Juego Actual");
                
                for(int i = 0; i < tableroJuego.GetLength(0); i++)
                {
                    for(int j = 0; j < tableroJuego.GetLength(1); j++)
                    {
                        if (tableroJuego[i,j] == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" " + tableroJuego[i, j]);
                            Console.ResetColor();
                        }
                        else if (tableroJuego[i,j] == 'O')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" " + tableroJuego[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" " + tableroJuego[i,j]); 
                        }
                    }
                    Console.WriteLine("\n");
                }
            }

            public bool GanarFila(char caracter)
            {
                for (int i = 0; i < tableroJuego.GetLength(0); i++)
                {
                    if (tableroJuego[i,0] == caracter && tableroJuego[i,1] == caracter && tableroJuego[i,2] == caracter)
                    {
                        return true; 
                    }
                }
                return false; 
            }


            public bool GanarColumna(char caracter)
            {
                for (int i = 0; i < tableroJuego.GetLength(1); i++)
                {
                    if (tableroJuego[0, i] == caracter && tableroJuego[1, i] == caracter && tableroJuego[2, i] == caracter)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool GanarDiagonal(char caracter) {

                if (tableroJuego[0,0] == caracter && tableroJuego[1,1] == caracter && tableroJuego[2,2] == caracter)
                {
                    return true; 
                }

                if (tableroJuego[0, 2] == caracter && tableroJuego[1, 1] == caracter && tableroJuego[2, 0] == caracter)
                {
                    return true;
                }

                return false; 
            }

            public bool ValidarTipoGanador(char caracter)
            {
                if (GanarFila(caracter)) { return true; }
                if (GanarColumna(caracter)) { return true;  }
                if(GanarDiagonal(caracter)) { return true; }
                return false;   
            }

            public bool VerificarEmpate(int numeroTurno)
            {
                if(numeroTurno == 9)
                {
                    Console.WriteLine(); 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ya no hay más movimientos, es EMPATE");
                    Console.ResetColor();
                    return true;
                }
                return false; 
            }

            public bool verificarEspacioDisponible(int posicion)
            {
                switch(posicion) {

                    case 1: return tableroJuego[0, 0] == '-';
                    case 2: return tableroJuego[0, 1] == '-';
                    case 3: return tableroJuego[0, 2] == '-';
                    case 4: return tableroJuego[1, 0] == '-';
                    case 5: return tableroJuego[1, 1] == '-';
                    case 6: return tableroJuego[1, 2] == '-';
                    case 7: return tableroJuego[2, 0] == '-';
                    case 8: return tableroJuego[2, 1] == '-';
                    case 9: return tableroJuego[2, 2] == '-';
                    default: 
                        return false;
                }
            }

            public void RegistrarJugada(char caracter)
            {
                bool movimientoValido = false;
                int PosicionSeleccionada;
                do
                {
                    try
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ingrese la posicion que desea ocupar");
                        PosicionSeleccionada = Convert.ToInt16(Console.ReadLine());

                        if (verificarEspacioDisponible(PosicionSeleccionada))
                        {
                            switch(PosicionSeleccionada)
                            {
                                case 1:
                                    tableroJuego[0, 0] = caracter;
                                    
                                    break;
                                case 2:
                                    tableroJuego[0, 1] = caracter;
                                    
                                    break;
                                case 3:
                                    tableroJuego[0, 2] = caracter;
                                    
                                    break;
                                case 4:
                                    tableroJuego[1, 0] = caracter;
                                    
                                    break;
                                case 5:
                                    tableroJuego[1, 1] = caracter;
                                    
                                    break;
                                case 6:
                                    tableroJuego[1, 2] = caracter;
                                    
                                    break;
                                case 7:
                                    tableroJuego[2, 0] = caracter;
                                    
                                    break;
                                case 8:
                                    tableroJuego[2, 1] = caracter;
                                    
                                    break;
                                case 9:
                                    tableroJuego[2, 2] = caracter;
                                    
                                    break;
                            }movimientoValido = true; 
                        }else if(PosicionSeleccionada > 9) {
                            Console.WriteLine($"Posicion {PosicionSeleccionada}, no valida, unicamente del 1 al 9");
                        }
                        else
                        {
                            Console.WriteLine($"La posicion: {PosicionSeleccionada} ya está ocupada, ingrese posición libre" + "\n");
                        }
                    }
                    catch(FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ingreso por teclado inválido");
                        Console.ResetColor();
                    }catch(Exception ex) {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error: {ex.Message}");
                        Console.ResetColor();
                    }
                } while (!movimientoValido); 
            }

            public bool repetirPartida(int Repetir)
            {
                if(Repetir == 1)
                {
                    InicializarTablero();
                    return true;
                }
                return false; 
            }


            public char seleccionarJugador()
            {
                char caracter = ' ';
                try
                {
                    caracter = (Convert.ToChar(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Caracter no valido, ingrese cualquera de las dos opciones disponibles");
                }

                return caracter;
            }


            public void ejecutarJuego()
            {   
                int RepetirPartida = 0;
                char caracter;
                bool terminarJuego = false;
                int nTurno = 1;
                InicializarTablero();

                do
                {
                    Console.WriteLine("¿Quién inicia Jugador 1 = X, Jugador 2 = O");
                    caracter = Char.ToUpper(seleccionarJugador());
                } while (caracter != 'X' && caracter != 'O');

                do
                {
                    Console.WriteLine();
                    MostrarTablero(); 
                    Console.WriteLine($"Turno del Jugador {caracter} , movimiento # {nTurno}" + "\n");
                    RegistrarJugada(caracter);
                    MostrarTablero();
                    juegoActual();

                    if (ValidarTipoGanador(caracter))
                    {
                        EscribirHistorialPartida();
                        if (caracter == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }else if(caracter == 'O')
                        {
                            Console.ForegroundColor= ConsoleColor.Blue;
                        }
                        
                        Console.WriteLine($"Ganador del Juego {caracter}");
                        Console.WriteLine("¡¡¡Gano ToTiTo!!!");
                        Console.ResetColor();

                        Console.WriteLine($"Desea volver a jugar 1 - 'Si' , 2 - 'No' ");
                        RepetirPartida = Convert.ToInt16(Console.ReadLine());
                        if (repetirPartida(RepetirPartida))
                        {
                            nTurno = 0;
                            RepetirPartida = 0;
                        }
                        else
                        {
                            Console.WriteLine("Cerrando Juego.....");
                            Thread.Sleep(4000);
                            terminarJuego = true;
                        }
                    }
                    else
                    {
                        if (VerificarEmpate(nTurno))
                        {
                            EscribirHistorialPartida();
                            Console.ResetColor();
                            Console.WriteLine($"Desea volver a jugar 1 - 'Si' , 2 - 'No' ");
                            RepetirPartida = Convert.ToInt16(Console.ReadLine());
                            if (repetirPartida(RepetirPartida))
                            {
                                nTurno = 0;
                                RepetirPartida = 0;
                                
                            }
                            else
                            {
                                Console.WriteLine("Cerrando Juego.....");
                                Thread.Sleep(4000);
                                terminarJuego = true;
                            }
                        }
                        else
                        {
                            if (caracter== 'X')
                            {
                                caracter = 'O';
                            }
                            else
                            {
                                caracter = 'X';
                            }
                        }
                    }
                    nTurno++;
                } while (!terminarJuego);
            }

            public void EscribirHistorialPartida()
            {
                Console.WriteLine("Historial de la Partida Actual");
                using(StreamWriter sw = new StreamWriter(HistorialJuego,true))
                {   
                    sw.WriteLine("Juego");
                    for (int i = 0; i < tableroJuego.GetLength(0); i++) {
                        
                        for (int j = 0; j < tableroJuego.GetLength(1); j++)
                        {
                            sw.Write(" " + tableroJuego[i,j]); 
                        }
                        sw.WriteLine(" ");
                    }
                    sw.WriteLine();
                    
                }
                
            }

            

            public void MostrarHistorial()
            {
                if (File.Exists(HistorialJuego))
                {
                    using (StreamReader read = new StreamReader(HistorialJuego))
                    {
                        int cont = 1;
                        string texto = " ";
                        while ((texto = read.ReadLine()) != null)
                        {
                            if (texto.Equals("Juego"))
                            {
                                texto = texto + " " + cont;
                                cont++;
                            }
                            Console.WriteLine(texto);
                        }
                        
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("El archivo no existe, tiene que jugar primero para generar un Historial");
                }
            }
        }



        static void Main(string[] args)
        {
            ControlesJuego controlesJuego = new ControlesJuego();
            int opcion;
            

            do
            {
                controlesJuego.menuPrincipal(); 
                opcion = controlesJuego.SolicitarOpcionMenu();
                
                switch (opcion) {
                    case 1:
                        controlesJuego.ejecutarJuego();
                        break; 
                    case 2:
                        controlesJuego.MostrarHistorial();
                        break; 
                    case 3:
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
