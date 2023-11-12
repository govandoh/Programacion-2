using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploConversionNumeroDecimalLetras
{
    internal class Program
    {
        static string[] units = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve" };
        static string[] teens = { "Diez", "Once", "Doce", "Trece", "Catorce", "Quince", "Dieciséis", "Diecisiete", "Dieciocho", "Diecinueve" };
        static string[] tens = { "", "", "Veinte", "Treinta", "Cuarenta", "Cincuenta", "Sesenta", "Setenta", "Ochenta", "Noventa" };
        static string[] thousands = { "", "Mil", "Millón", "Mil Millones", "Billón" };

        static string ConvertNumberToWords(int number)
        
        {
            if (number < 10)
                return units[number];
            if (number < 20)
                return teens[number - 10];
            if (number < 100)
                return $"{tens[number / 10]}{(number % 10 > 0 ? $" y {ConvertNumberToWords(number % 10)}" : "")}";
            if (number < 1000)
                return $"{units[number / 100]} Cientos {(number % 100 > 0 ? $" {ConvertNumberToWords(number % 100)}" : "")}";

            for (int i = 0; i < thousands.Length; i++)
            {
                if (number < 1000 * (long)Math.Pow(1000,i))
                {
                    string _restoDelTexto = "";
                    if (number % (int)Math.Pow(1000, i) > 0)
                    {
                        _restoDelTexto = ConvertNumberToWords(number % (int)Math.Pow(1000, i));
                    }
                    return $"{ConvertNumberToWords(number / (int)Math.Pow(1000, i))} {thousands[i]}{(!string.IsNullOrEmpty(_restoDelTexto) ? $" {_restoDelTexto}" : "")}";
                }
            }
            return "Número demasiado grande";
        }


        /*
         for (int i = 0; i < thousands.Length - 1; i++)
                {
                    if (number < 1000 * (long)Math.Pow(1000, i + 1))
                        return $"{ConvertNumberToWords(number / (int)Math.Pow(1000, i))} {thousands[i]}{(number % (int)Math.Pow(1000, i) > 0 ? $" {ConvertNumberToWords(number % (int)Math.Pow(1000, i))}" : "")}";
                }
                return "Número demasiado grande";
            }
         */


        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un número decimal:");
            if (decimal.TryParse(Console.ReadLine(), out decimal inputNumber))
            {
                int intPart = (int)inputNumber;
                int fractionalPart = (int)((inputNumber - intPart) * 100);
                string words = $"{ConvertNumberToWords(intPart)} {(intPart == 1 ? "Quetzales " : "Quetzales")} {(fractionalPart > 0 ? $"con {ConvertNumberToWords(fractionalPart)} {(fractionalPart == 1 ? "Centavo" : "Centavos")}" : "")}";
                Console.WriteLine($"El número {inputNumber} en palabras es: {words}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Entrada no válida. Ingrese un número decimal válido.");
            }
        }
    }
}