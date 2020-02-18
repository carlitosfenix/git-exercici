using System;
using System.Collections.Generic;
using System.Text;

namespace _1_ConsoleAppVariables
{
    class RegistroAlumnos
    {
        public void RegistrarAlumnos()
        {
            var keyWordOut = "runyoufools";
            List<double> miList = new List<double>();
            bool keepDoing = true;
            string entradaUser;
            while (keepDoing)
            {
                Console.WriteLine($"Por favor, entra la nota del alumno....{miList.Count + 1}");
                entradaUser = Console.ReadLine();
                var notaAsignada = 0.0;
                //Si usamos , la sustituimos
                entradaUser.Replace(",",".");
                if (Double.TryParse(entradaUser, out notaAsignada))
                {
                    miList.Add(notaAsignada);
                }
                else if (entradaUser == keyWordOut)
                {
                    keepDoing = false;
                }
                else
                {
                    Console.WriteLine("Por favor, entre un valor correcto para nota....");
                }

            }

            double notaMedia;
            double notaMax;
            double notaMin;
            double sumaTotal = 0; 

            foreach (double ele in miList)
            {
                sumaTotal += ele;
            }

            notaMedia = sumaTotal / (miList.Count + 1);
            //Ordenamos con lo que el primero de la lista será el menor
            miList.Sort();
            notaMin = miList[0];
            notaMax = miList[miList.Count-1];

            Console.WriteLine($"Med: {notaMedia} Min: {notaMin} Max: {notaMax}");
           

        }

    }

}


