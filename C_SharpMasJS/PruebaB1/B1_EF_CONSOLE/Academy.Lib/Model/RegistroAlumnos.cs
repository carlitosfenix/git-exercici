using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_4_DbContext.Lib.Model
{
    /**
     * Versión previa al modelo
     */
    public class RegistroAlumnos
    {
        private static double _entradaUser;
        private static double _notaMedia;
        private static double _notaMax;
        private static double _notaMin;
        private static List<double> _miList = new List<double>();

        public static double EntradaUser { get => _entradaUser; set => _entradaUser = value; }
        public static double NotaMedia { get => _notaMedia; set => _notaMedia = value; }
        public static double NotaMax { get => _notaMax; set => _notaMax = value; }
        public static double NotaMin { get => _notaMin; set => _notaMin = value; }
        public static List<double> MiList { get => _miList; set => _miList = value; }

        public void RegistrarAlumno(double entradaUser)
        {
           
          
                EntradaUser = entradaUser;
                Console.WriteLine($"Por favor, entra la nota del alumno....{MiList.Count + 1}");
         
                
                MiList.Add(EntradaUser);
              
               
        }

        public void CalcularMaxMedMin()
        {
            double sumaTotal = 0;

            foreach (double ele in MiList)
            {
                sumaTotal += ele;
            }

            NotaMedia = sumaTotal / (MiList.Count + 1);
            //Ordenamos, con lo que el primero de la lista será el menor
            MiList.Sort();
            NotaMin = MiList[0];
            NotaMax = MiList[MiList.Count - 1];

            Console.WriteLine($"Med: {NotaMedia} Min: {NotaMin} Max: {NotaMax}");
        }

    }
}
