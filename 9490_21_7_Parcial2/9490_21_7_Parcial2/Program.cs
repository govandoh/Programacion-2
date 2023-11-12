using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _9490_21_7_Parcial2
{
    internal class Program
    {

        
        static void menu()
            {
                Console.WriteLine("Examen Parcial 2");
                Console.WriteLine($"Opciones: " + "\n" + "1. Ingreso y suma de diagonal" + "\n" + "2. Totito" + "\n" + "3. Salir" + "\n");
            }
            
            static void calculoMatriz()
            {
            int[,] matriz;  
                int fila = 0;
                int columna = 0;

            
                
            do {
                 try
                 {
                      Console.WriteLine("Ingrese el numero de filas para la matriz" + "\n");
                      fila = Convert.ToInt32(Console.ReadLine());
                      Console.WriteLine("Ingrese el numero de columnas para la matriz" + "\n");
                      columna = Convert.ToInt32(Console.ReadLine());
                      
                      matriz = new int[fila,columna];

                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            Console.WriteLine($"Ingrese el valor para la posicion {i + 1}, {j + 1}");
                            matriz[i,j] = Convert.ToInt32(Console.ReadLine());
                        }
                    }


                    for(int i = 0; i < 1; i++)
                    {   
                        int suma = 0;
                        for(int j = 0; j < matriz.GetLength(1); j++)
                        {
                            suma = suma + matriz[i,j];
                            
                        }
                        Console.WriteLine($"La suma de la priemra fila es: {suma}");
                        Console.WriteLine("\n");
                    }

                    for (int i = (fila -1) ; i < matriz.GetLength(0); i++)
                    {
                        int suma = 0;
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            suma = suma + matriz[i, j];

                        }
                        Console.WriteLine($"La suma de la ultima fila es: {suma}");
                        Console.WriteLine("\n");
                    }

                    int r = 0; 
                    
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        int suma = 0;     
                        suma = suma + matriz[i, i];
                        r = r + suma;  
                    }
                    Console.WriteLine($"La suma de Diagonal D - I es: {r}");
                    Console.WriteLine("\n");

                    int diagonal2 = columna-1;

                    int r2 = 0; 
                    for(int i = 0; i < matriz.GetLength(0); i++)
                    {   
                        r2 = r2 + matriz[i, diagonal2--]; 
                    }
                    Console.WriteLine("La suma de la diagonal secundaria es: " + r2);



                }
                catch (FormatException)
                            {
                                Console.WriteLine("Error con el dato ingresado ingrese uno valido");
                            }catch(OverflowException){
                    Console.WriteLine("Error relacionado a las dimensiones de la matriz");
                            
                  }
            } while (fila <= 0 || columna <= 0);
       
            }



        static char[,] mTotito = new char[3, 3];
        static void inicializarTotito(){
            
            for (int i = 0; i < mTotito.GetLength(0); i++)
                {
                    for(int j = 0; j < mTotito.GetLength(1); j++)
                    {
                        mTotito[i, j] = '-';
                    }
                }
            }


            static void mostrarTablero()
            {
                int posicion = 1;

                for (int i = 0; i < mTotito.GetLength(0); i++)
                {
                    for (int j = 0; j < mTotito.GetLength(1); j++)
                    {
                        if (mTotito[i, j] == 'X' || mTotito[i,j] == 'O') {
                            Console.Write(" " + mTotito[i,j]);
                        }
                        else
                        {
                            Console.Write(" " + posicion);
                        }
                        posicion++;
                    }
                    Console.WriteLine(" ");
                }
            }

        static void mostrarJuego()
        {
            Console.WriteLine();
            Console.WriteLine("Juego Actual");
            for (int i = 0; i < mTotito.GetLength(0); i++)
            {
                for (int j = 0; j < mTotito.GetLength(1); j++)
                {
                    if (mTotito[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" " + mTotito[i, j]);
                        Console.ResetColor();
                        
                    }
                    else if (mTotito[i,j] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + mTotito[i, j]);
                        Console.ResetColor();
                    }else 
                    {
                        Console.Write(" " + mTotito[i,j]);
                    }
                   
                }
                Console.WriteLine("\n");
            }
        }

        static bool verificarEspacio(int posicion)
        {
            switch(posicion)
            {
                case 1: return mTotito[0, 0] == '-';
                case 2: return mTotito[0, 1] == '-';
                case 3: return mTotito[0, 2] == '-';
                case 4: return mTotito[1, 0] == '-';
                case 5: return mTotito[1, 1] == '-';
                case 6: return mTotito[1, 2] == '-';
                case 7: return mTotito[2, 0] == '-';
                case 8: return mTotito[2, 1] == '-';
                case 9: return mTotito[2, 2] == '-';
                default: return false; 
            }
        }

        static void registrarMovimiento(char caracter)
        {
            bool moves = false;
            int posicion;
            do
            {
                try
                {
                    Console.WriteLine($"Ingrese la posicion que desea jugar");
                    posicion = Convert.ToInt32(Console.ReadLine());
                    if (verificarEspacio(posicion))
                    {
                        switch (posicion)
                        {
                            case 1:
                                mTotito[0, 0] = caracter;
                                break;
                            case 2:
                                mTotito[0, 1] = caracter;
                                break;
                            case 3:
                                mTotito[0, 2] = caracter;
                                break;
                            case 4:
                                mTotito[1, 0] = caracter;
                                break;
                            case 5:
                                mTotito[1, 1] = caracter;
                                break;
                            case 6:
                                mTotito[1, 2] = caracter;
                                break;
                            case 7:
                                mTotito[2, 0] = caracter;
                                break;
                            case 8:
                                mTotito[2, 1] = caracter;
                                break;
                            case 9:
                                mTotito[2, 2] = caracter;
                                break;
                        }
                        moves = true;
                    }else if(posicion > 9)
                    {
                        Console.WriteLine("Ingrese una posicion del 1 al 9 unicamente" + "\n");
                    }
                    else
                    {
                        Console.WriteLine($"La posicion {posicion}, ya fue ocupada, seleccione una libre" + "\n");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Caracter no valida, ingrese uno correcto");
                }
            } while(!moves);
        }

        static bool validarFila(char caracter)
        {
            for(int i = 0; i < mTotito.GetLength(0); i++)
            {
                if (mTotito[i, 0] == caracter && mTotito[i,1] == caracter && mTotito[i,2] == caracter)
                {
                    return true;
                }
            }
            return false; 
        }

        static bool validarColumna(char caracter)
        {
            for (int i = 0; i < mTotito.GetLength(1); i++)
            {
                if (mTotito[0, i] == caracter && mTotito[1, i] == caracter && mTotito[2, i] == caracter)
                {
                    return true;
                }
            }
            return false; 
        }

        static bool validarDiagonal(char caracter)
        {
            if (mTotito[0,0] == caracter && mTotito[1,1] == caracter && mTotito[2,2] == caracter)
            {
                return true; 
            }else if (mTotito[0, 2] == caracter && mTotito[1, 1] == caracter && mTotito[2, 0] == caracter)
            {
                return true;
            }
            return false; 
        }

        static bool validarGanador(char caracter)
        {
            if (validarFila(caracter)) { return true;}
            if(validarColumna(caracter)) { return true; }
            if(validarDiagonal(caracter)) { return true; }
            return false;

        }

        static bool validarEmpate(int turno)
        {   

            if (turno == 9){
                Console.WriteLine($"Es empate termino el juego");
                return true;
            }
            return false; 
        }

        static void Main(string[] args)
        {
            int opcion = 0;


            do{
                menu();
                Console.WriteLine("Ingrese por teclado la opcion que desea ejecutar"); 
                opcion = Convert.ToInt32(Console.ReadLine());

                switch(opcion)
                {
                    case 1: Console.WriteLine("Programa 1 ");
                        opcion = 0;
                        calculoMatriz();
                        break;
                    case 2: Console.WriteLine("Totito");
                        inicializarTotito();
                        int nTurno = 0; 
                        bool terminarJuego = false;
                        char caracter = 'X';

                        mostrarTablero();
                        do
                        {
                            Console.WriteLine($"Turno del jugador: {caracter}"); Console.WriteLine("\n");
                            registrarMovimiento(caracter);
                            mostrarTablero();
                            mostrarJuego();
                            if(validarGanador(caracter)){
                                Console.WriteLine();
                                Console.WriteLine($"Gano totito Jugador {caracter}") ;
                                terminarJuego = true;
                            } else {
                                if (validarEmpate(nTurno))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"Gano totito Jugador {caracter}");
                                    terminarJuego = true;
                                }
                                else
                                {
                                    if(caracter == 'X')
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
                        break;
                    case 3:
                        break;
                }
            
            }while(opcion !=3);

        }
    }
}
