using System;

namespace _1_ConsoleAppVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            var numA = 5;
            var numB = 6;
            var suma = numA + numB;
            Console.WriteLine("Hello World! " + suma);

            // Console.ReadKey();

            variablesPorAsignacion();
            variablesTipadas();
            parseEntradaNumero();
            operadores();
            sayHello();
            var resultado = Suma(45,20);
            Console.WriteLine($"El resultado del método suma es: {resultado}");




        }


        public static void operadores() {
            /*Veamos que podemos hacer lo mismo que en java*/

            int intOne = 1;
            var intTwo = 2;

            intOne += 3;
            intTwo++;

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("La variable intOne vale: " + intOne++);
            Console.WriteLine("La variable intOne vale: " + intOne);
            Console.WriteLine("-------------------------------------");


        }

        public static void sayHello() {
            var textOut = "Hello";
            Console.WriteLine("Saludo" + textOut);
            Console.WriteLine($"Saludo-2: {textOut}");
            Console.WriteLine(String.Format("Saludo-3 {0}", textOut));

        }

        public static int Suma(int a, int b){

            return a+b;
        }

        
    public static void variablesPorAsignacion(){
        var entero = 23;
        var decimales = 45.5m;//sufijo m para tipo decimal
        var doble=0.5d;
        var fechaTiempo = DateTime.Now;
        var texto = "ejemplo de texo"; 
        var caracter = 'u'; //comilla simple
        var siOno = true;
        Console.WriteLine("Variables por asignacion: "+entero+", "+decimales+", "+fechaTiempo+", "+doble+", "+texto+", "+caracter+", "+siOno );  
    }

    public static void variablesTipadas(){
        int entero =23;
        decimal decimales = 45.5m;
        double doble=0.5d;
        DateTime fechaTiempo = DateTime.Now;
        DateTime fechaTiempo2= new DateTime();
        String texto = "ejemplo de texo"; 
        char caracter = 'u'; //comilla simple
        bool siOno = true;
        Console.WriteLine("Variables tipadas: "+entero+", "+decimales+", "+fechaTiempo2+", "+doble+", "+texto+", "+caracter+", "+siOno );
    }

        public static void parseEntradaNumero() {

            Console.WriteLine("Entra un número");
            var entrada = Console.ReadLine();
            int enteroCorrecto;
            if (int.TryParse(entrada, out enteroCorrecto))
            {
                Console.WriteLine("conversión correcta: " + enteroCorrecto);
            }
            else
            {
                Console.WriteLine("No has entrado un número filtrada por TryParse");
            }

            try
            {
                var entero = int.Parse(entrada);

            }
            catch (System.Exception e)
            {
                Console.WriteLine("No has entrado un número, petada en try Catch, error = " + e);
            }

        } 
    }

}
