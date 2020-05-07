using Academy.Lib.Infrastructure;
using Academy.Lib.Models;
using System.Collections.Generic;

namespace Academy.Lib.Context
{
    public class StudentRepository : Repository<Student>
    {
        private static Dictionary<string, Student> StudentsByDni { get; set; } = new Dictionary<string, Student>();

        public override SaveResult<Student> Add(Student entity)
        {
            
            var output = new SaveResult<Student>() { Entity = entity};

            if (StudentsByDni.ContainsKey(entity.Dni))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Ya existe este Student con ese dni");
            }

            if (output.IsSuccess)
            {
                StudentsByDni.Add(output.Entity.Dni, output.Entity);
            }

            return output;
        }

        public override SaveResult<Student> Update(Student entity)
        {
           
            var output = new SaveResult<Student>() { Entity = entity };
            var check = entity.Validate(); 
            if (!check.IsSuccess)
            {
                output.IsSuccess = false;
                output.Validation.Errors = check.Errors;
            }     
            if (!StudentsByDni.ContainsKey(output.Entity.Dni))
            {
                output.Validation.Errors.Add($"No hay el alumno con este dni {output.Entity.Dni} !");
            }
            if (output.IsSuccess)
            {
                StudentsByDni[output.Entity.Dni] = output.Entity;
            }

            return output;
        }

        public override DeleteResult<Student> Delete(Student entity)
        {
            var output = new DeleteResult<Student>() { Entity = entity };

            if (output.DeleteValidationSuccesful)
            {
                StudentsByDni.Remove(output.Entity.Dni);
            }

            return output;
        }

        public Student GetStudentByDni(string dni)
        {
            if (StudentsByDni.ContainsKey(dni))
                return StudentsByDni[dni];

            return null;
        }
        public Dictionary<string, Student> GetAllStudents()
        {
            return StudentsByDni;
        }
    }
}
