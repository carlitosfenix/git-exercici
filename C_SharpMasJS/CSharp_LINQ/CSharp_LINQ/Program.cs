using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_LINQ
{
    class Program
    {

        static int[] Numeros = { 2, 6, 8, 4, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };
        static int[] Pares;
        static int[] Menores5;
        static int[] Mayores5;
        

        static void Main(string[] args)
        {
            Console.WriteLine("CSharp LINQ y estilo fluido o Fluent");
            GuardarNumerosPares();
            MostrarConsolaNumeroPares();
            CalcularMediaMaxMin();
            NumerosMayores5();
            NumerosMenores5(); //Al pobre 5 no lo tenemos en cuenta, lo discriminamos
            //Fase 4. Trabajando con Strings desde LINQ
            TrabajandoConStrings();
        }

        private static void TrabajandoConStrings()
        {
            string[] nombres = { "David", "Sergio", "Laura", "Maria", "Oscar", "Julia", "Oriol" };
            Fase4 miStrings = new Fase4(nombres);
            miStrings.ComeinzanPor("o");
            miStrings.MasDeXLetras(5);
            miStrings.OrderDesc();
        }

        private static void MostrarConsolaNumeroPares()
        {
            Console.WriteLine("mostrarConsolaNumeroPares() " + Fase4.Separador);
            foreach (int elemento in Pares)
            {
                Console.WriteLine($"{elemento}");
            }
        }

        private static void GuardarNumerosPares()
        {
            var tmpPares = from par in Numeros
                           where (par % 2) == 0
                           orderby par
                           select par;

            Console.WriteLine("guardarNumerosPares() " + Fase4.Separador);
            int longitud = tmpPares.Count();
            Pares = new int[longitud];
            var count = 0;
            foreach (var result in tmpPares)
            {
                Console.WriteLine(result);
                Pares[count] = result;
                count++;
            }


        }

        private static void CalcularMediaMaxMin()
        {
            var tmpIEnumerable = from num in Pares
                                 select num;
            int max = tmpIEnumerable.Max();
            int min = tmpIEnumerable.Min();
            var avg = tmpIEnumerable.Average();

            Console.WriteLine("calcularMediaMaxMin() " + Fase4.Separador);
            Console.WriteLine($"El valor Max: {max}, el Min: {min} y el Medio: {avg}");


        }
        #region fase1
        private static void NumerosMayores5()
        {
            Console.WriteLine("NumerosMayores5() " + Fase4.Separador);
            var mayores5 = from num in Numeros
                           where num > 5
                           orderby num
                           select  num ; // new {num} cuidado, si hacemos un new crearemos un tipo anonimo dificil de convertir

            int longitud = mayores5.Count();
            Mayores5 = new int[longitud];
            int posicion = 0;
            foreach (var elemento in mayores5)
            {
                Console.WriteLine($"{elemento}");
                Mayores5[posicion] = elemento;
                posicion++;


            }

        }
        private static void NumerosMenores5()
        { 
            //En este caso lo hacemos fluido
            Console.WriteLine("NumerosMenores5() " + Fase4.Separador);
            var menores5 = Numeros
                .Where(num => num < 5)
                .OrderBy(num => num)
                .Select(num => num); // new { num });creamos tipo anónimo

            int longitud = menores5.Count();
            Menores5 = new int[longitud];
            int posicion = 0;
            foreach (var elemento in menores5)
            {
                Console.WriteLine($"{elemento}");
                Menores5[posicion] = elemento;
                posicion++;

            }
        }
        #endregion fase 1
    }
}
