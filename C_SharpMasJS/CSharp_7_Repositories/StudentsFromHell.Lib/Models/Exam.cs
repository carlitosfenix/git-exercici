using Academy.Lib.Context;
using Academy.Lib.Infrastructure;
using System;

namespace Academy.Lib.Models
{
    public class Exam : Entity
    {
        public DateTime DateTimeExam { get; set; }

        public Subject Subject { get; set; }

        public Student Student { get; set; }

        public double Score { get; set; }

        public Guid Guid { get; private set; }

        private static string alumnoEncontrado = "existe un alumno con ese dni";
        private static string asignaturaEncontrada = "existe una asignatura que se llama";

        public Exam(Student student, Subject subject, DateTime dateTimeExam, double score)
        {
            Student = student;
            Subject = subject;
            DateTimeExam = dateTimeExam;
            Score = score;
        }

        private static double ValidarNota(string score)
        {
          
            double nota = Double.TryParse(score, out nota) ? nota:-1;
            if (nota >= 0 && nota <= 10)
            {
                return nota;
            }
            return -1;
        }

        #region Validaciones de clase 
        public static ValidationResult<double> ValidateNote(string score)
        {
            double doubleScore = -1.0;
            var validationResult = new ValidationResult<double>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(score))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add("se ha de informar el valor de nota");
            }
            else if (ValidarNota(score) < 0)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add("La nota ha de ser una valor numérico comprendido entre 0.0 y 10.0");
            }
            else
            {
                doubleScore = ValidarNota(score);
            }
            if (validationResult.IsSuccess)
            {
                validationResult.ValidatedResult = doubleScore;
            }

            return validationResult;
        }

        public static ValidationResult<DateTime> ValidateDate(DateTime dateTime)
        {
            int thisYear = DateTime.Now.Year;
            int examYear = dateTime.Year;

            var validationResult = new ValidationResult<DateTime>()
            {
                IsSuccess = true
            };
            if (dateTime == null)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add("La fecha del examen no puede ser nula");
            }
            else if (examYear < (thisYear - 1) || examYear > (thisYear + 1))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add($"Sólo se pueden registrar examenes entre los años {thisYear - 1} y {thisYear + 1}");
            }
            else
            {
                validationResult.ValidatedResult = dateTime;
            }
            
            return validationResult;
        }
        public static ValidationResult<Student> ValidateStudent(string dni, bool first)
        {
            ValidationResult<Student> valiReStudent = new ValidationResult<Student>();
            valiReStudent.IsSuccess = false;
            //Primero le encargamos a la clase Student que verifique el DNI
            ValidationResult<string> vrDni = Student.ValidateDni(dni);
            
            if (vrDni.AllErrors.Contains(alumnoEncontrado))
            {
                vrDni.IsSuccess = true;
            }
            else
            {
                if (!first) Console.WriteLine(vrDni.AllErrors);
            }
            
            if (vrDni.IsSuccess)
            {   //Si es correcto hay que buscarlo   
                valiReStudent.IsSuccess = true;

                StudentRepository studentRepository = new StudentRepository();
                valiReStudent.ValidatedResult = studentRepository.GetStudentByDni(dni);
                if (valiReStudent.ValidatedResult == null)
                {
                    valiReStudent.IsSuccess = false;
                    valiReStudent.Errors.Add("no hay alumno con este Dni");
                }
            }
            return valiReStudent;
        }

        public static ValidationResult<Subject> ValidateSubject(string subjectName, bool first)
        {
            ValidationResult<Subject> valiReSubject = new ValidationResult<Subject>();
            valiReSubject.IsSuccess = false;
            //Primero le encargamos a la clase Student que verifique el DNI
            ValidationResult<string> vrAsignatura = Subject.ValidateName(subjectName);

            if (vrAsignatura.AllErrors.Contains(asignaturaEncontrada))
            {
                vrAsignatura.IsSuccess = true;
            }
            else
            {
                if (!first) Console.WriteLine(vrAsignatura.AllErrors);
            }

            if (vrAsignatura.IsSuccess)
            {   //Si es correcto hay que buscarla  
                valiReSubject.IsSuccess = true;

                SubjectRepository subjectRepository = new SubjectRepository();
                valiReSubject.ValidatedResult = subjectRepository.GetSubjectByName(subjectName);
                if (valiReSubject.ValidatedResult == null)
                {
                    valiReSubject.IsSuccess = false;
                    valiReSubject.Errors.Add("no se ha encontrado la asignatura");
                }
            }

            return valiReSubject;
        }
        #endregion Validaciones de clase
    }


}
