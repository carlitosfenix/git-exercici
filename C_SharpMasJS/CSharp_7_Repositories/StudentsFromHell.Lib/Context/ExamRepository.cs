using Academy.Lib.Infrastructure;
using Academy.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Lib.Context
{
    public class ExamRepository : Repository<Exam>
    {
        public static Dictionary<string, Exam> ExamByDniDate { get; set; } = new Dictionary <string, Exam>();
        /// <summary>
        /// Agrega un nuevo examen a ExamByDniDate con la Key (entity.Student.Dni + "/" + entity.DateTimeExam)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override SaveResult<Exam> Add(Exam entity)
        {
            //var output = base.Add(entity);
            var output = new SaveResult<Exam>() { Entity = entity };

            if (ExamByDniDate.ContainsKey(entity.Student.Dni + "/" + entity.DateTimeExam))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Ya existe un examen de este alumno y el mismo time stamp");
            }

            if (output.IsSuccess)
            {
                ExamByDniDate.Add(output.Entity.Student.Dni + "/" + entity.DateTimeExam, output.Entity);
            }

            return output;
        }

        public override SaveResult<Exam> Update(Exam entity)
        {
            //var output = base.Update(entity);
            var output = new SaveResult<Exam>() { Entity = entity };
            var check = entity.Validate();
            if (!check.IsSuccess)
            {
                output.IsSuccess = false;
                output.Validation.Errors = check.Errors;
            }
            if (!ExamByDniDate.ContainsKey(entity.Student.Dni + "/" + entity.DateTimeExam))
            {
                output.Validation.Errors.Add($"No hay examen de: {entity.Student.Dni} en {entity.DateTimeExam} !");
            }
            if (output.IsSuccess)
            {
                ExamByDniDate[entity.Student.Dni + "/" + entity.DateTimeExam] = output.Entity;
            }

            return output;
        }

        public override DeleteResult<Exam> Delete(Exam entity)
        {
            var output = new DeleteResult<Exam>() { Entity = entity };

            if (output.DeleteValidationSuccesful)
            {
                ExamByDniDate.Remove(entity.Student.Dni + "/" + entity.DateTimeExam);
            }

            return output;
        }

       /// <summary>
       /// EWste metodo devuelve todas las coincidencias de claves que contenga el DNI
       /// </summary>
       /// <param name="dni"></param>
       /// <returns></returns>
        public IEnumerable<KeyValuePair<string, Exam>> GetExamsByDni(string dni)
        {
            return ExamByDniDate.Where(kvp => kvp.Key.Contains(dni)).Select(kvp => kvp);
        }

        public Dictionary<string, Exam> GetAllExamns()
        {
            return ExamByDniDate;
        }

        public IEnumerable<KeyValuePair<string, Exam>> GetExamsByDate(DateTime dateTime)
        {
            return ExamByDniDate.Where(kvp => kvp.Key.Contains(""+dateTime)).Select(kvp => kvp);
        }
    }
}