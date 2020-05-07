using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using Academy.Lib.Context;
using Academy.Lib.Infrastructure;

namespace Academy.Lib.Models
{
    public class Student : Entity
    {

        public enum ResultDNI
        {
            LongitudIncorrecta = 0,
            NumeroNoValido = 1,
            CharNoValido = 2,
            Correcto = 3
            //Si devuelve un char, será la letra que le corresponde
        }
        #region Static Validations

        public static ValidationResult<string> ValidateDni(string dni, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(dni))
            {
                output.IsSuccess = false;
                output.Errors.Add("el dni del alumno no puede estar vacío");
            }

            #region check duplication
            var repo = new StudentRepository();
            var entityWithDni = repo.GetStudentByDni(dni);

            if (currentId == default && entityWithDni != null)
            {
                // on create
                output.IsSuccess = false;
                output.Errors.Add("ya existe un alumno con ese dni");
            }
            else if (currentId != default && entityWithDni.Id != currentId)
            {
                // on update
                output.IsSuccess = false;
                output.Errors.Add("ya existe un alumno con ese dni");
            }
            else if (!ValidarDNI(dni).Equals(ResultDNI.Correcto))
            {
                output.IsSuccess = false;
                ResultDNI error = ValidarDNI(dni);

                var salida = "Revise el DNI, ";
                switch (error)
                {
                    case Student.ResultDNI.CharNoValido:
                        salida += "letra no corresponde.";
                        break;
                    case Student.ResultDNI.LongitudIncorrecta:
                        salida += "el formato correcto es de 8 numeros y una letra";
                        break;
                    case Student.ResultDNI.NumeroNoValido:
                        salida += "el número no es valido";
                        break;
                    case Student.ResultDNI.Correcto:
                        salida = "";
                        break;
                }
                output.Errors.Add(salida);
            }


            #endregion

            if (output.IsSuccess)
            {
                output.ValidatedResult = dni;
                
            }

            return output;
        }

        public static ValidationResult<int> ValidateChairNumber(string chairNumberText, Guid CurrentId=default)
        {
            var output = new ValidationResult<int>()
            {
                IsSuccess = true
            };

            var chairNumber = 0;
            var isConversionOk = false;

            #region check null or empty
            if (string.IsNullOrEmpty(chairNumberText))
            {
                output.IsSuccess = false;
                output.Errors.Add("el número de la silla no puede estar vacío o nulo");
            }
            #endregion

            #region check format conversion

            isConversionOk = int.TryParse(chairNumberText, out chairNumber);

            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add($"no se puede convertir {chairNumber} en número");
            }

            #endregion

            #region verificamos si OTRO alumno tiene la misma silla

            if (isConversionOk)
            {
                var repoStudents = new Repository<Student>();
                var otherStudentInChair = repoStudents.QueryAll().Where(x => x.ChairNumber == chairNumber && ! x.Id.Equals(CurrentId) ).FirstOrDefault();
               
                if (otherStudentInChair != null)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"ya hay un alumno {otherStudentInChair.Name} en la silla {chairNumber}");
                }
            }
            #endregion

            if (output.IsSuccess)
                output.ValidatedResult = chairNumber;

            return output;
        }

        public static ValidationResult<string> ValidateName(string name)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("el nombre delalumno no puede estar vacío");
            }
            else if (!ValidarNombre(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("Se debe entrar al menos un nombre (máximo 3 para telenovelas) y dos apellidos");
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }

        #endregion

        public string Dni { get; set; }
        public string Name { get; set; }

        public int ChairNumber { get; set; }

       

        public Guid Guid { get; private set; }

        #region Domain Validations

        public void ValidateName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateName(this.Name);
            if (!validateNameResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateNameResult.Errors);
            }
        }

        public void ValidateDni(ValidationResult validationResult)
        {            
            var vr = ValidateDni(this.Dni, this.Id);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateChairNumber(ValidationResult validationResult)
        {
            var vr = ValidateChairNumber(this.ChairNumber.ToString(), this.Id);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        #endregion

        public SaveResult<Student> Save()
        {            
            var saveResult = base.Save<Student>();
            return saveResult;
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            
            ValidateName(output);
            ValidateDni(output);
            ValidateChairNumber(output);

            return output;
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
                bool tenemosNumero = int.TryParse(dni.Substring(0, 8), out var partNumero);
                bool tenemosCharFinal = char.TryParse(dni.Substring(dni.Length - 1, 1), out var charDelDNI);
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
            if (nomApellidos.Length >= 3 && nomApellidos.Length <=5)
            {
                foreach (string elemento in nomApellidos)
                {
                    if (elemento.Length < 2 || elemento.Length > 16) return false;
                }
                return true;
            }
            return false;
        }


    }
}
