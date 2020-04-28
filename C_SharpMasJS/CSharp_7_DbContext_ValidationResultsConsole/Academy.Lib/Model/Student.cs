using Academy_4_DbContext.Lib.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_4_DbContext.Lib.Model
{ 
    public class Student : Entity
    {
         public enum ResultDNI
        {
            LongitudIncorrecta = 0,
            NumeroNoValido     = 1,
            CharNoValido       = 2,
            Correcto = 3
            //Si devuelve un char, será la letra que le corresponde
        }
        private string _name;
        private string _dni;
        private List<Exam> _exams;

        public string Name { get => _name; set => _name = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public List<Exam> Exams { get => _exams; set => _exams = value; }

        public Student(string name, string dni)
        {
            Name = name;
            Dni = dni;
        }

        public bool AddExam(Exam newExam)
        {
            Exams.Add(newExam);
            return true;
        }
        /// <summary>
        /// Versión muy básica solo sirve para DNI, faltaría implementar NIE
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        static public ResultDNI ValidarDNI(string dni)
        {
            dni = dni.Trim();
            int longitud = dni.Length;
            if (longitud == 9)
            {
                bool tenemosNumero = int.TryParse(dni.Substring(0,8), out var partNumero);
                bool tenemosCharFinal = char.TryParse (dni.Substring(dni.Length-1, 1), out var charDelDNI);
                if (tenemosNumero && tenemosCharFinal)
                {
                    if (charDelDNI == CharDelDNI(partNumero)) return ResultDNI.Correcto;

                    return ResultDNI.CharNoValido;
                }
                else if (tenemosNumero)
                {
                    return ResultDNI.CharNoValido;
                }
                else
                {
                    return ResultDNI.NumeroNoValido;
                }
               
            } 
            else
            {
                return ResultDNI.LongitudIncorrecta;
            }
            
        }
        /// <summary>
        /// devuelve la letra correspondiente a un número DNI
        /// </summary>
        /// <param name="numeroDNI"></param>
        /// <returns></returns>
        static private char CharDelDNI(int numeroDNI)
        {
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            char letra = letras[numeroDNI % 23];
            return letra;
        }

        static public bool ValidarNombre(string nombre)
        {
            nombre = nombre.Trim();
            string[] nomApellidos = nombre.Split();
            if (nomApellidos.Length == 3) { 
                foreach (string elemento in nomApellidos)
                {
                    if (elemento.Length < 2 || elemento.Length > 16) return false;
                }
                return true;
            }
            return false;
        
        }

        public SaveResult<Student> Save()
        {
            var saveResult = base.Save<Student>();
            return saveResult;
        }

      
    }
}

