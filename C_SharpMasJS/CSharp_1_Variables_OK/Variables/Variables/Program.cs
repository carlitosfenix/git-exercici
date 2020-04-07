using System;

namespace Variables
{
    class Program
    {
        static private readonly string BloqueT = "------------------------";
        static private readonly string BloqueSeparador = "------------------------ FIN FASE  ------------------------";
        static private string Tab = "   ";
        static int[] AnysTraspas;
        static int AnyNacimiento;
        static string NombreCompleto;
        static string DataNaixement;
        static bool TuAnyIsBisiesto;

        static public void Main(string[] args)
        {
            Console.WriteLine($"{Tab}{BloqueT} VARIABLES {BloqueT}");

            FaseUno();
            FaseDos();
            FaseTres();
            FaseCuatro();
        }


        static private void FaseUno() 
        {
            Console.WriteLine($"{Tab}{BloqueT}  FASE-I   {BloqueT}");
            string nom = "Carlos";
            string cognom1 = "Acevedo";
            string cognom2 = "Jiménez";

            int dia = 3;
            int mes = 2;
            int any = 2020;

            NombreCompleto = $"{Tab}{Tab}{cognom2} {cognom1}, {nom}";
            DataNaixement = $"{Tab}{Tab}{dia}/{mes}/{any}";
            Console.WriteLine(NombreCompleto);
            Console.WriteLine(DataNaixement);
            Console.WriteLine(Tab + BloqueSeparador);
        }

        #region FASE DOS (II)
        static private void FaseDos()
        {
            Console.WriteLine($"{Tab}{BloqueT}  FASE-II  {BloqueT}");
            const int anyOrigen = 1948;
            Console.WriteLine($"{Tab}{BloqueT}Introduzca su año de nacimiento:");
            AnyNacimiento = MiConsole.CapturaAnyNacimiento(); 
            AnysTraspas = VerQueAnysSonBisiestos(anyOrigen, AnyNacimiento);
            string inicioFrase = Tab + $"La cantidad de Anys de Traspàs desde el 1948 hasta (tu año de nacimiento) {AnyNacimiento}, es de: ";
            int cuentaBisiestos = AnysTraspas.Length;
            Console.WriteLine(Tab + inicioFrase + cuentaBisiestos);
            Console.WriteLine(Tab + BloqueSeparador);
        }

        /// <summary>
        /// Devolverá un array con los años bisiestos desde "anyInicio"
        /// hasta "anyFinal" 
        /// </summary>
        /// <param name="anyInicio"></param>
        /// <param name="anyFinal"></param>
        /// <returns></returns>
        static private int[] VerQueAnysSonBisiestos(int anyInicio, int anyFinal)
        { 
            int[] anysTraspas = new int[0];

            for (var any = anyInicio; any <= anyFinal; any++)
            {
                if (EsBisiesto(any))
                {
                    Array.Resize(ref anysTraspas, anysTraspas.Length + 1);
                    anysTraspas[anysTraspas.Length-1] = any;
                }
            }
            return anysTraspas;
        }
        #endregion FASE DOS (II)

        /// <summary>
        /// Un año es bisiesto en el calendario Gregoriano:
        ///  si es divisible entre 4 y no divisible entre 100, y también si es divisible entre 400.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        static private bool EsBisiesto(int any)
        {
            var esBisiesto = any % 4;
            if ((esBisiesto == 0 && any % 100 > 0) || (any % 400 == 0))
            {
                return true;
            }
            return false;
        }
        

        static private void FaseTres()
        {
            Console.WriteLine($"{Tab}{BloqueT}  FASE-III {BloqueT}");
            Console.WriteLine(Tab +  Tab + "Los años bisiestos desde 1984 hasta tu año son: ");
            foreach (int anyBisiseto in AnysTraspas) 
            {
                Console.WriteLine(Tab + Tab + Tab + anyBisiseto);
            }

            TuAnyIsBisiesto = EsBisiesto(AnyNacimiento);
            string afirmativo = $"Tu año de nacimiento {AnyNacimiento} SÍ es Bisiesto";
            string negativo = $"Tu año de nacimiento {AnyNacimiento} NO es Bisiesto";
            Console.WriteLine(TuAnyIsBisiesto ? afirmativo: negativo);
            Console.WriteLine(Tab + BloqueSeparador);
        }

        static private void FaseCuatro()
        {
            Console.WriteLine($"{Tab}{BloqueT}  FASE-IV   {BloqueT}");
            string reNombre   = "El meu nom és: " + NombreCompleto;
            string reFecha    = "Vaig néixer el: " + DataNaixement;
            string reLoes = TuAnyIsBisiesto ? "és de traspàs" : "no es de traspàs";
            string reBisiesto = $"El meu any de naixement " + reLoes;

            Console.WriteLine(Tab + reNombre);
            Console.WriteLine(Tab + reFecha);
            Console.WriteLine(Tab + reBisiesto);

            Console.WriteLine(Tab + BloqueSeparador);

        }
    }
}
