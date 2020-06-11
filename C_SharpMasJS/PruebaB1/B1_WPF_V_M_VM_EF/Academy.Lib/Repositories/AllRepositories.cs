using Academy_4_DbContext.Lib.Model;
using Academy_4_DbContext.Lib.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Academy.Lib.Context
{
    public  class AllRepositories 
    {
        public bool TenemosAlumno = false;
        public bool TenemosMateria = false;
        public bool TenemosExams = false;
        public static string NewLine => "\r\n";



        #region CRUDs Student
      

        /*Version ValidationResults */
        public SaveResult<Student> SaveStudent(Student student)
        {
            using (AcademyDbContext context = new AcademyDbContext())
            {
                var output = new SaveResult<Student>() { Entity = student };
                
                if (student != null)
                {
                    try
                    {
                        var result = context.ListaStudents.Where(x => x.Dni.Equals(student.Dni));

                        if (result != null && result.Count() > 0)
                        {
                            output.IsSuccess = false;
                            output.Validation.Errors.Add($"El alumno {result.First().Name} ya está registrado con este dni, por favor, reviselos.");

                        }
                        else
                        {
                            output.IsSuccess = true;
                            context.Add(student);
                            context.SaveChanges();
                            student.Save();
                            output.Validation.Errors.Add("Alumno guardado correctamente. ¿Qué quieres hacer ahora?");
                        }
                    }
                    catch(MySql.Data.MySqlClient.MySqlException e)
                    {
                        Console.WriteLine($"Se ha producido un error con el SGBD con error code:{e.ErrorCode} y por el motivo: {e.Message}");
                        Console.WriteLine($"En caso de Unknown Database, Fíjate que la base de datos esté creada y que tengas acceso al server");
                        Console.WriteLine($"Si no está creada recuerda: desde consola de administración de paquetes: add-migration y add-database");
                    }
                }
                else
                {
                    output.Validation.Errors.Add("Los campos Nombre y/o DNI no contienen información o no es válida");
                }
                Console.WriteLine(output.AllErrors);
                return output;
            }
      }







        public Student SelectStudentByDNI(string dni)
        {
            using (AcademyDbContext context = new AcademyDbContext())
            {
                Student result =  context.ListaStudents.FirstOrDefault(x => x.Dni.Equals(dni));

                if (result != null)
                {
                    return result;
                }
                /* if (result.Any()) 
                 { 
                     return result.First().Value;
                 }*/
                return result;
            }
        }

        /// <summary>
        /// Actualizará el nombre del alumno por el DNI y nos devolverá el nombre anterior
        /// </summary>
        /// <param name="txtBoxNombre"></param>
        /// <param name="txtBoxDni"></param>
        /// <returns>Nombre anterior para update combobox</returns>
        public string UpdateStudent(string txtBoxNombre, string txtBoxDni)
        {
            List<Student> tmpListStudents;
            using (AcademyDbContext context = new AcademyDbContext())
            {
                tmpListStudents = context.ListaStudents.ToList();
            }
                var anterior = "";
                var salida = "";
                if (!string.IsNullOrWhiteSpace(txtBoxNombre) && !string.IsNullOrWhiteSpace(txtBoxDni))
                {
                    Student dummyStudent = new Student(txtBoxNombre, txtBoxDni);
                    foreach (Student student in tmpListStudents)
                    {
                        if (txtBoxDni.Equals(student.Dni))
                        {
                            anterior = student.Name;
                            student.Name = txtBoxNombre;
                            using (AcademyDbContext context = new AcademyDbContext())
                            {
                                context.Update(student);
                                context.SaveChanges();
                            }
                            salida = $"Se ha actualizado el nombre del alumno con dni {txtBoxDni}";
                            return anterior;
                        }
                        else
                        {
                            salida = $"No se ha localizado ningún alumno con el {txtBoxDni}";
                        }
                    }
                }
                else
                {
                    salida = "Los campos Nombre y/o DNI no contienen información o no es válida";
                }
                Console.WriteLine(salida);
                return anterior;
        }

        

        public string DeleteStudent(string txtBoxNombre, string txtBoxDni)
        {
            
            if (!string.IsNullOrWhiteSpace(txtBoxNombre) && !string.IsNullOrWhiteSpace(txtBoxDni))
            {
                using (AcademyDbContext context = new AcademyDbContext())
                {

                    context.ListaStudents.Remove(SelectStudentByDNI(txtBoxDni));
                    context.SaveChanges();

                }
                /* TODO
                Guid guid = DictionayStudents.FirstOrDefault(x => x.Value.Dni == txtBoxDni).Key;
                DictionayStudents.Remove(guid);
                DniIndexStudents.Remove(txtBoxDni);
                */
                //Borramos si coinciden los dos campos exactamente
                //Student dummyStudent = new Student(txtBoxNombre, txtBoxDni);
                //ListaStudents.Remove(dummyStudent);
                //Borramos si coincide el DNI en listas
                //ListaStudents.RemoveAll(x => x.Dni.Equals(dummyStudent.Dni) );

                Console.WriteLine("Alumno borrado correctamente");
            }
            else
            {
                Console.WriteLine("Los campos Nombre y/o DNI no contienen información o no es válida");
                txtBoxNombre = null;
            }
            return txtBoxNombre;
        }
        /// <summary>
        /// Imprimime por consola los alumnos. Devuelve la cantidad de alumnos +1 (lo que 1 es = 0 alumnos)
        /// </summary>
        public  List<Student> ListStudents()
        {
            List<Student> tmpListStudents;
            using (AcademyDbContext context = new AcademyDbContext())
            {
                tmpListStudents = context.ListaStudents.ToList();
                int posicion = 1;
                foreach (Student student in context.ListaStudents)
                {
                    Console.WriteLine($"{posicion}-) {student.Name} con DNI: {student.Dni}");
                    posicion++;
                }
                return tmpListStudents;
            }
        }
        /// <summary>
        /// Devolverá todos los examenes del parámetro Student por dni
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public  string ListExamsAlumno(Student student)
        {
            var salida = "";
            int posicion = 1;
            Guid studentGuid = student.Id;
            List<Exam> tmpListExams;
            using (AcademyDbContext context = new AcademyDbContext())
            {
                tmpListExams = context.ListaExams.ToList();
            }
                foreach (Exam exam in tmpListExams)
                {
                    if (exam.StudentGuid.Equals(studentGuid))
                    {
                        using (AcademyDbContext context = new AcademyDbContext())
                        {
                            Subject subject = context.ListaSubjets.FirstOrDefault(x => x.Id.Equals(exam.SubjectGuid));
                            salida += $"{posicion}-) El día {exam.DateTimeExam} el alumno {student.Name} en la materia {subject.Name}, ha obtenido una nota de {exam.Score}. {NewLine}";
                        }
                        posicion++;
                    }
                }
            return salida;
        }
        #endregion CRUDs Student

        #region CRUDs Subjects
        public Subject RegistrarNewSubject(string txtBoxMateria, string txtBoxTeachear)
        {
            using (AcademyDbContext context = new AcademyDbContext())
            {
                Subject resultSubject = null;
                if (!string.IsNullOrWhiteSpace(txtBoxMateria) && !string.IsNullOrWhiteSpace(txtBoxTeachear))
                {
                    Subject dummySubject = new Subject(txtBoxMateria, txtBoxTeachear);
                    var result = context.ListaSubjets.Where(x => x.Name.Equals(txtBoxMateria));
                    if (result != null && result.Count() > 0)
                    {
                        Console.WriteLine($"SOS esa materia ya la imparte {result.First().Teacher}");
                    }
                    else
                    {
                        context.ListaSubjets.Add(dummySubject);
                        context.SaveChanges();
                        Console.WriteLine($"Materia {dummySubject.Name} impartida por {dummySubject.Teacher}, guardada correctamente");
                        resultSubject = dummySubject;
                    }
                }
                else
                {
                    Console.WriteLine("Los campos Subject y/o Teacher no contienen información o no es válida");
                }
                return resultSubject;
            }
        }

        /// <summary>
        /// Actualizará la materia según el Teacher y nos devolverá el valor anterior
        /// </summary>
        /// <param name="txtBoxMateria"></param>
        /// <param name="txtBoxTeachear"></param>
        /// <returns>Nombre anterior para update combobox</returns>
        public  string UpdateSubject(string txtBoxMateria, string txtBoxTeachear)
        {
            List<Subject> tmpListSubjects;
            using (AcademyDbContext context = new AcademyDbContext())
            {
                tmpListSubjects = context.ListaSubjets.ToList();
            }
                var salida = "";
                var anterior = "";
                if (!string.IsNullOrWhiteSpace(txtBoxMateria) && !string.IsNullOrWhiteSpace(txtBoxTeachear))
                {
                    Subject dummySubject = new Subject(txtBoxMateria, txtBoxTeachear);
                    foreach (Subject subject in tmpListSubjects)
                    {
                        if (dummySubject.Name.Equals(subject.Name))
                        {
                            anterior = subject.Teacher;
                            subject.Teacher = txtBoxTeachear;
                            using (AcademyDbContext context = new AcademyDbContext())
                            {
                                context.Update(subject);
                                context.SaveChanges();
                            }
                        
                            salida = $"Se ha actualizado la materia {txtBoxMateria},  ahora la imparte {txtBoxTeachear}";
                            return anterior;
                        }
                        else
                        {
                            salida = $"No se ha localizado la asignatura {txtBoxMateria}";
                        }
                    }
                }
                else
                {
                    salida = "Los campos Materia y/o Teacher no contienen información o no es válida";
                }
                Console.WriteLine(salida);
                return anterior;
        }
        

        public  string DeleteSubject(string txtBoxMateria, string txtBoxTeachear) 
        {
            if (!string.IsNullOrWhiteSpace(txtBoxMateria) && !string.IsNullOrWhiteSpace(txtBoxTeachear))
            {
                using (AcademyDbContext context = new AcademyDbContext())
                {
                    //Borramos si coinciden los dos campos exactamente
                    Subject dummySubject = new Subject(txtBoxMateria, txtBoxTeachear);
                    context.ListaSubjets.Remove(dummySubject);
                    context.SaveChanges();
                    //Borramos si coincide con la materia
                    // ListaSubjets.Remove(x => x.Name.Equals(dummySubject.Name));
                    Console.WriteLine("Subject borrada correctamente");
                }
            }
            else
            {
                Console.WriteLine("Los campos Materia y/o Teacher no contienen información o no es válida");
                txtBoxTeachear = null;
            }
            return txtBoxMateria;
        }

        public List<Subject> ListSubjets()
        {
            int posicion = 1;
            List<Subject> tmpListSubjects;
            using (AcademyDbContext context = new AcademyDbContext())
            {
                tmpListSubjects = context.ListaSubjets.ToList();
                foreach (Subject subjet in context.ListaSubjets)
                {
                    Console.WriteLine($"{posicion}-) {subjet.Name} imparte: {subjet.Teacher}");
                    posicion++;
                }
            }
            return tmpListSubjects;
        }

        public Subject SelectSubjetByName(string name)
        {
            using (AcademyDbContext context = new AcademyDbContext())
            {
                var result = context.ListaSubjets.Where(x => x.Name.Equals(name));
                if (result.Any())
                {
                    return result.First();
                }
                return null;
            }
        }
        #endregion CRUDs Subjects

        #region CRUDS Exams

        public  string RegistrarNewExam(Guid student, Guid subject, DateTime timeStamp, double score)
        {
            using (AcademyDbContext context = new AcademyDbContext())
            {
                var salida = "";
                Exam dummyExam = new Exam(student, subject, timeStamp, score);
                var result = context.ListaExams.Where(x => x.StudentGuid.Equals(dummyExam.StudentGuid)
                && x.SubjectGuid.Equals(dummyExam.SubjectGuid) && x.DateTimeExam.Equals(dummyExam.DateTimeExam));
                if (result != null && result.Count() > 0)
                {
                    salida = "SOS este alumno ya ha realizado este examen en la misma fecha";
                }
                else
                {
                    context.ListaExams.Add(dummyExam);
                    context.SaveChanges();
                    salida = "Examen guardado correctamente";
                }
                return salida;
            }
        }


        public  string UpdateExam(Guid studentGuid, Guid subjectGuid, DateTime timeStamp, double score) 
        {
            using (AcademyDbContext context = new AcademyDbContext())
            {
                Student student = context.ListaStudents.FirstOrDefault(x => x.Id.Equals(studentGuid));
                Subject subject = context.ListaSubjets.FirstOrDefault(x => x.Id.Equals(subjectGuid));

                var salida = "";
                if ((student != null) && (subject != null) && (timeStamp != null))
                {
                    Exam dummyExam = new Exam(studentGuid, subjectGuid, timeStamp, score);

                    foreach (Exam exam in context.ListaExams)
                    {
                        if (studentGuid.Equals(student.Id) && subjectGuid.Equals(subject.Id))
                        {
                            salida = $"Se ha actualizado la nota a {student.Name}   por el profesor {subject.Teacher}";
                            exam.DateTimeExam = timeStamp;
                            exam.Score = score;
                            context.Update(exam);
                            context.SaveChanges();
                            return salida;
                        }
                        else
                        {
                            salida = $"No se ha localizado el examen de la materia " +
                                $"{subject.Name} para {student.Name}." +
                                $" Si quiere lo puede dar de alta clicando en Add Exam ";
                        }
                    }
                }
                else
                {
                    salida = "Falta informar algún campo o la información no es válida";
                }
                return salida;
            }
        }

        /* TODO: refactorizar y usar pero con guid para simplificar!!!
        public static string DeleteExam(int indxAlumno, int indxMateria, DateTime timeStamp, string notaTexto)
        {
            var salida = "";
            Student dummyStudent = DictionayStudents.ElementAt(indxAlumno).Value;
            Subject dummySubject = ListaSubjets[indxMateria];


            if ((indxAlumno >= 0) && (indxMateria >= 0)
               && !string.IsNullOrWhiteSpace(notaTexto) && double.TryParse(notaTexto , out var score)
               && (timeStamp != null))
            {
                //Borramos si coinciden todos los campos exactamente
                Exam dummyExam = new Exam(dummyStudent, dummySubject, timeStamp, score);
                ListaExams.Remove(dummyExam);
                //Borramos si coincide con la materia, el profesor y la fecha
                //ListaExams.RemoveAll(x => x.Student.Equals(dummyStudent) && x.Subject.Equals(dummySubject)
                && x.DateTimeExam.Equals(timeStamp));
                salida = "Examen borrado correctamente";
            }
            else
            {
                salida = "La información introducada no corresponde con ningún examen";
            }
            return salida;
        }*/

        public List<Exam> ListExamsTodos() 
        {
            var salida = "";
            int posicion = 1;
            List<Exam> TmpListExams;
            using (AcademyDbContext context = new AcademyDbContext())
            {
                
                TmpListExams = context.ListaExams.ToList();
            }
            foreach (Exam exam in TmpListExams)
            {
                using (AcademyDbContext context = new AcademyDbContext())
                {
                    Student student = context.ListaStudents.FirstOrDefault(x => x.Id.Equals(exam.StudentGuid));
                    Subject subject = context.ListaSubjets.FirstOrDefault(x => x.Id.Equals(exam.SubjectGuid));
                    salida += $"{posicion}-) El día {exam.DateTimeExam} el alumno {student.Name} en la materia {subject.Name}, ha obtenido una nota de {exam.Score}. {NewLine}";
                    posicion++;
                }
                
            }
            Console.WriteLine(salida);
            return TmpListExams;
        }
        



        #endregion CRUDS Exams


        public  void CalcularMaxMedMin()
        {

            //Exam notaMin = context.ListaExams.Aggregate((i1, i2) => i1.Score < i2.Score ? i1 : i2);
            //Exam notaMax = context.ListaExams.Aggregate((i1, i2) => i1.Score > i2.Score ? i1 : i2);
            using (AcademyDbContext context = new AcademyDbContext())
            {
                double notaMedia = context.ListaExams.Average(x => x.Score);
                List<Exam> tmpMNotaMinExams = context.ListaExams.ToList();
                List<Exam> tmpMNotaMaxExams = context.ListaExams.ToList();
                Exam notaMin = tmpMNotaMinExams.Aggregate((i1, i2) => i1.Score < i2.Score ? i1 : i2);
                Exam notaMax = tmpMNotaMaxExams.Aggregate((i1, i2) => i1.Score > i2.Score ? i1 : i2);
                Console.WriteLine($"Med: {notaMedia} Min: {notaMin.Score} Max: {notaMax.Score}");
            }
        }
    }
}
