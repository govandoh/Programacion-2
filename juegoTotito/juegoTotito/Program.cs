using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;

namespace juegoTotito
{

    internal class Program
    {
        class controladorJuego
        {
            public char[,] tablero = new char[3, 3];

            //Genera el tablero de posiciones, y verifica si ya existe un valor X o O en el tablero
            public void generarTablero()
            {
                int posicion = 1;
                Console.WriteLine();
                Console.WriteLine($" Estas son las posiciones del tablero, Puedo ingresar X o O en posiciones no ocupadas");
                for (int i = 0; i < tablero.GetLength(0); i++)
                {
                    for (int j = 0; j < tablero.GetLength(1); j++)
                    {
                        
                        if (tablero[i, j] == 'X' || tablero[i, j] == 'O')
                        {
                            Console.Write("|" + tablero[i, j] + "|");
                            
                        }
                        else
                        {
                            Console.Write("|" + posicion + "|");
                            
                        }
                        posicion++;
                    }
                    
                    Console.WriteLine("\n");
                }
            }

            //Rellena el tablero para jugar
            public void rellenarTablero()
            {
                for (int i = 0; i < tablero.GetLength(0); i++)
                {
                    for (int j = 0; j < tablero.GetLength(1); j++)
                    {
                        tablero[i, j] = '-';
                    }
                }
            }

            //Muestra como está el tablero del Juego actual
            public void mostrarJuegoActual()
            {
                Console.WriteLine();
                Console.WriteLine("Juego Actual");
                for (int i = 0; i < tablero.GetLength(0); i++)
                {
                    for (int j = 0; j < tablero.GetLength(1); j++)
                    {

                        if (tablero[i, j] == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" " + tablero[i, j]);
                            Console.ResetColor();
                        }
                        else if (tablero[i, j] == 'O')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" " + tablero[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" " + tablero[i, j]);
                        }
                    }
                    Console.WriteLine("\n");
                }
            }

            //metodo que retorna el caracter ingresado por consola, sirve para asignar jugador inicial
            public char seleccionarJugador()
            {
                char caracter = ' ';    
                try
                {
                    caracter = (Convert.ToChar(Console.ReadLine()));
                }
                catch (FormatException) {
                    Console.WriteLine("Caracter no valido, ingrese cualquera de las dos opciones disponibles"); 
                }
                
                return caracter;
            }

            //metodo unitario que tiene como responsabilidad verificar si el jugador en turno gano por medio de filas

            public bool verificarFilaG(char caracter)
            {
                for (int i = 0; i < tablero.GetLength(0); i++)
                {
                    if (tablero[i, 0] == caracter && tablero[i, 1] == caracter && tablero[i, 2] == caracter)
                    {
                        return true;
                    }
                }
                return false;
            }
            //metodo unitario que tiene como responsabilidad verificar si el jugador en turno gano por medio de columnas

            public bool verificarColumnaG(char caracter)
            {
                for (int i = 0; i < tablero.GetLength(1); i++)
                {
                    if (tablero[0, i] == caracter && tablero[1, i] == caracter && tablero[2, i] == caracter)
                    {
                        return true;
                    }
                }
                return false;
            }

            //metodo unitario que tiene como responsabilidad verificar si el jugador en turno gano por medio de las dos posibles diagonales
            public bool verificiarDiagonalesG(char caracter)
            {
                if (tablero[0, 0] == caracter && tablero[1, 1] == caracter && tablero[2, 2] == caracter)
                {
                    return true;
                }

                if (tablero[0, 2] == caracter && tablero[1, 1] == caracter && tablero[2, 0] == caracter)
                {
                    return true;
                }
                return false;
            }

            //metodo booleano que agrupa los tres tipos de formas de ganar, valida cada uno de las opciones, durante el turno actual
            public bool validarGanar(char caracter)
            {
                if (verificarFilaG(caracter)) { return true; }
                if (verificarColumnaG(caracter)) { return true; }
                if (verificiarDiagonalesG(caracter)) { return true; }
                return false;
            }

            /*  metodo booleano que verifica si ya no hay mas movimientos o espacios para jugar, recibe como parametro el numero de turno, al verificar que no se 
                ganó por ninguna de las otras 3 formas va verificando si ya es el turno 9, en este juego no hay mas de 9 turnos.
             */
            public bool verificarEmpate(int numeroTurno)
            {
                if (numeroTurno == 9)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ya no hay espacios, es empate");
                    return true;
                }
                return false;
            }

            /*  Verifica el espacio, si la casilla no está ocupada permite ingresar la jugada, como el metodo rellenar tabla
                llena todos los espacion con '-', este metodo verifica si en la posicion [i,j] aun está con '-', si no se cumple retorna falso.
             */
            public Boolean verificarEspacio_Tablero(int posicion)
            {
                switch (posicion)
                {
                    case 1: return tablero[0, 0] == '-';
                    case 2: return tablero[0, 1] == '-';
                    case 3: return tablero[0, 2] == '-';
                    case 4: return tablero[1, 0] == '-';
                    case 5: return tablero[1, 1] == '-';
                    case 6: return tablero[1, 2] == '-';
                    case 7: return tablero[2, 0] == '-';
                    case 8: return tablero[2, 1] == '-';
                    case 9: return tablero[2, 2] == '-';
                    default: return false;
                }
            }


            /*
                Logica principal del problema, la variable moves, verificar si se pudo ejecutar la jugada o no, y seleccionar posicion sirve para el switch
                se solicita la posicion desea, y en el if se manda a llamar el metodo que verifica si el tablero ya esta ocupado, si se ejecuta el metodo, ejecuta 
                el switch, y escribe en la matriz, segun la posicion elegida, moves para a true, esto ayuda a terminar esa jugada. 
             */
            public void registroMovimientos(char fichaJugador)
            {
                bool moves = false;
                int seleccion_posicion;
                do
                {
                    try
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ingrese la posicion que desea ocupar");
                        seleccion_posicion = Convert.ToInt16(Console.ReadLine());

                        if (verificarEspacio_Tablero(seleccion_posicion))
                        {
                            switch (seleccion_posicion)
                            {
                                case 1:
                                    tablero[0, 0] = fichaJugador;
                                    break;
                                case 2:
                                    tablero[0, 1] = fichaJugador;
                                    break;
                                case 3:
                                    tablero[0, 2] = fichaJugador;
                                    break;
                                case 4:
                                    tablero[1, 0] = fichaJugador;
                                    break;
                                case 5:
                                    tablero[1, 1] = fichaJugador;
                                    break;
                                case 6:
                                    tablero[1, 2] = fichaJugador;
                                    break;
                                case 7:
                                    tablero[2, 0] = fichaJugador;
                                    break;
                                case 8:
                                    tablero[2, 1] = fichaJugador;
                                    break;
                                case 9:
                                    tablero[2, 2] = fichaJugador;
                                    break;
                            }
                            moves = true;
                        }else if (seleccion_posicion > 9) {
                            Console.WriteLine($"Ingrese una posición valida, solo del 1 al 9" + "\n");
                        }
                        else
                        {
                            Console.WriteLine($"La posicion: {seleccion_posicion} ya está ocupada, ingrese posición libre" + "\n");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingreso no valido");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($" Error, Detalle: {ex.Message}");
                    }
                } while (!moves);
            }

            public bool repetir(int opcion)
            {
                if (opcion == 1)
                {
                    rellenarTablero();
                    return true;
                }
                return false;
            }
        }

        static void Main(string[] args)
        {
            controladorJuego controlador = new controladorJuego();
            int repetir_Juego = 0;
            char asignarJugador = ' ';
            char turno;
            char jugador1 = ' ';
            char jugador2 = ' ';
            bool terminaJuego = false;
            int nTurno = 1;
            

            controlador.rellenarTablero();
            do
            {
                Console.WriteLine("¿Quién inicia Jugador 1 = X, Jugador 2 = O");
                asignarJugador = Char.ToUpper(controlador.seleccionarJugador());
            } while (asignarJugador != 'X' && asignarJugador != 'O');


            turno = asignarJugador;
            if (asignarJugador == 'X')
            {
                jugador1 = 'X';
                jugador2 = 'O';
            }
            else if (asignarJugador == 'O')
            {
                jugador1 = 'O';
                jugador2 = 'X';
            }

            do
            {
                Console.WriteLine();
                controlador.generarTablero();
                Console.WriteLine($"Turno del Jugador {turno} , movimiento # {nTurno}" + "\n");
                controlador.registroMovimientos(turno);
                controlador.generarTablero();
                controlador.mostrarJuegoActual();

                if (controlador.validarGanar(turno))
                {
                    if (turno == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (turno == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                    }

                    Console.WriteLine($"Ganador del Juego {turno}");
                    Console.WriteLine("¡¡¡Gano ToTiTo!!!");
                    Console.ResetColor();

                    Console.WriteLine($"Desea volver a jugar 1 - 'Si' , 2 - 'No' ");
                    repetir_Juego = Convert.ToInt16(Console.ReadLine());
                    if (controlador.repetir(repetir_Juego))
                    {
                        nTurno = 0;
                        repetir_Juego = 0;
                    }
                    else
                    {
                        Console.WriteLine("Cerrando Juego.....");
                        Thread.Sleep(4000);
                        terminaJuego = true;
                    }


                }
                else
                {
                    if (controlador.verificarEmpate(nTurno))
                    {

                        Console.ResetColor();
                        Console.WriteLine($"Desea volver a jugar 1 - 'Si' , 2 - 'No' ");
                        repetir_Juego = Convert.ToInt16(Console.ReadLine());
                        if (controlador.repetir(repetir_Juego))
                        {
                            nTurno = 0;
                            repetir_Juego = 0;
                        }
                        else
                        {
                            Console.WriteLine("Cerrando Juego.....");
                            Thread.Sleep(4000);
                            terminaJuego = true;
                        }
                    }else{
                        if (turno == jugador1)
                        {
                            turno = jugador2;
                        }
                        else
                        {
                            turno = jugador1; 
                        }
                            
                    }
                    
                }
                nTurno++;
            } while (!terminaJuego);
        }
    }
}

