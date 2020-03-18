using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_LINQ
{
    class Program
    {

        static int[] Numeros = { 2, 6, 8, 4, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };
        static int[] Pares;
        static string Separador = "*****************************************************";

        static void Main(string[] args)
        {
            Console.WriteLine("CSharp LINQ y estilo fluido o Fluent");
            guardarNumerosPares();
            mostrarConsolaNumeroPares();
            calcularMediaMaxMin();
        }

      

        private static void mostrarConsolaNumeroPares()
        {
            Console.WriteLine("mostrarConsolaNumeroPares() " + Separador);
            foreach (int elemento in Pares) {
                Console.WriteLine($"{elemento}");
            }
        }

        private static void guardarNumerosPares()
        {
            var tmpPares = from par in Numeros
                    where (par % 2) == 0
                    orderby par
                    select par;

            Console.WriteLine("guardarNumerosPares() " + Separador);
            int longitud = tmpPares.Count();
            Pares = new int[longitud];
            var count = 0;
            foreach (var result in tmpPares) {
                Console.WriteLine(result);
                Pares[count]= result;
                count++;
            }


        }

        private static void calcularMediaMaxMin()
        {
            var tmpIEnumerable = from num in Pares
                        select num;
            int max = tmpIEnumerable.Max();
            int min = tmpIEnumerable.Min();
            var avg = tmpIEnumerable.Average();

            Console.WriteLine("calcularMediaMaxMin() " + Separador);
            Console.WriteLine($"El valor Max: {max}, el Min: {min} y el Medio: {avg}" );


        }
    }
}
