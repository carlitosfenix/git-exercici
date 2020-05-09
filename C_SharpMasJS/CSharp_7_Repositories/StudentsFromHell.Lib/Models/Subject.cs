using Academy.Lib.Context;
using Academy.Lib.Infrastructure;
using System;

namespace Academy.Lib.Models
{
    public class Subject : Entity
    {
        //Atributos
        public string Name { get; set; }
        public string Teacher { get; set; }
        public Guid Guid { get; private set; }


        #region Validaciones de clase 
        public static ValidationResult<string>  ValidateName(String name)
        {
            var validationResult = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add("el nombre de la asignatura no puede estar vacío");
            }
            else if (SubjectRepository.SubjectsByName.ContainsKey(name))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add($"Ya existe una asignatura que se llama {name}");
            }
            if (!ValidarNameOrTeacherString(name))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add("El nombre de la asignatura ha de tener una longitud correcta (entre 3 y 19)");
            }
            if (validationResult.IsSuccess)
            {
                validationResult.ValidatedResult = name;
            }

            return validationResult;
        }

        public static ValidationResult<string>  ValidateTeacher(string teacher)
        {
            var validationResult = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            validationResult.IsSuccess = true;

            if (string.IsNullOrEmpty(teacher))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add("el nombre del  profesor no puede estar vacío");
            }
            if (!ValidarNameOrTeacherString(teacher))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add("El nombre del profesor ha de tener una longitud correcta (entre 3 y 19)");
            }
            return validationResult;
        }
        #endregion Validaciones de clase

     

        public SaveResult<Subject> Save()
        {
            var saveResult = base.Save<Subject>();
            return saveResult;
        }

        static public bool ValidarNameOrTeacherString(string nombre)
        {

            if (nombre.Length > 2 && nombre.Length < 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
