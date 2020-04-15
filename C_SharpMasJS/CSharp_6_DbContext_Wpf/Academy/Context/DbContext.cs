using Academy_4_DbContext.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Lib.Context
{
    public static class DbContext
    {
        static  Dictionary <Guid, Student> DictionayStudents = new Dictionary <Guid, Student>();
        static List<Subject> ListaSubjets = new List<Subject>();
        static List<Exam> ListaExams = new List<Exam>();
        static public bool TenemosAlumno = false;
        static public bool TenemosMateria = false;

        #region CRUDs Student
        static public Student RegistrarNewStudent(string txtBoxNombre, string txtBoxDni)
        {
            Student resultStudent = null;
            if (!string.IsNullOrWhiteSpace(txtBoxNombre) && !string.IsNullOrWhiteSpace(txtBoxDni))
            {
                Student dummyStudent = new Student(txtBoxNombre, txtBoxDni);
                var result = DictionayStudents.Where(x => x.Value.Dni.Equals(txtBoxDni));
                if (result != null && result.Count() > 0)
                {
                    Console.WriteLine("SOS hay otro alumno con este dni");
                }
                else
                {
                    DictionayStudents.Add(dummyStudent.Id,dummyStudent);
                    Console.WriteLine("Alumno guardado correctamente");
                    resultStudent = dummyStudent;
                }

            }
            else
            {
                Console.WriteLine("Los campos Nombre y/o DNI no contienen información o no es válida");
            }
            return resultStudent;
        }

        /// <summary>
        /// Actualizará el nombre del alumno por el DNI y nos devolverá el anterior
        /// </summary>
        /// <param name="txtBoxNombre"></param>
        /// <param name="txtBoxDni"></param>
        /// <returns>Nombre anterior para update combobox</returns>
        static public string UpdateStudent(string txtBoxNombre, string txtBoxDni)
        {
            var anterior = "";
            var salida = "";
            if (!string.IsNullOrWhiteSpace(txtBoxNombre) && !string.IsNullOrWhiteSpace(txtBoxDni))
            {
                Student dummyStudent = new Student(txtBoxNombre, txtBoxDni);
                foreach (Student student in DictionayStudents.Values)
                {
                    if (txtBoxDni.Equals(student.Dni))
                    {
                        anterior = student.Name;
                        student.Name = txtBoxNombre;
                        salida = $"Se ha actualizado el nombre del alumno con dni {txtBoxDni}" ;

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

        static public string DeleteStudent(string txtBoxNombre, string txtBoxDni)
        {
            
            if (!string.IsNullOrWhiteSpace(txtBoxNombre) && !string.IsNullOrWhiteSpace(txtBoxDni))
            {
                
                Guid guid = DictionayStudents.FirstOrDefault(x => x.Value.Dni == txtBoxDni).Key;
                DictionayStudents.Remove(guid);
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

        public static void ListStudents()
        {
            int posicion = 1;
            foreach (Student student in DictionayStudents.Values)
            {
                Console.WriteLine($"{posicion}-) {student.Name} con DNI: {student.Dni}");
                posicion++;
            }
        }
        #endregion CRUDs Student

        #region CRUDs Subjects
        static public Subject RegistrarNewSubject(string txtBoxMateria, string txtBoxTeachear)
        {
            Subject resultSubject = null;
            if (!string.IsNullOrWhiteSpace(txtBoxMateria) && !string.IsNullOrWhiteSpace(txtBoxTeachear))
            {
                Subject dummySubject = new Subject(txtBoxMateria, txtBoxTeachear);
                var result = ListaSubjets.Where(x => x.Name.Equals(txtBoxMateria));
                if (result != null && result.Count() > 0)
                {
                    Console.WriteLine($"SOS esa materia ya la imparte {result.First().Teacher}");
                }
                else
                {
                    ListaSubjets.Add(dummySubject);
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

        /// <summary>
        /// Actualizará la materia según el Teacher y nos devolverá el valor anterior
        /// </summary>
        /// <param name="txtBoxMateria"></param>
        /// <param name="txtBoxTeachear"></param>
        /// <returns>Nombre anterior para update combobox</returns>
        public static string UpdateSubject(string txtBoxMateria, string txtBoxTeachear)
        {
            var anterior = "";
            if (!string.IsNullOrWhiteSpace(txtBoxMateria) && !string.IsNullOrWhiteSpace(txtBoxTeachear))
            {
                Subject dummySubject = new Subject(txtBoxMateria, txtBoxTeachear);
                foreach (Subject subject in ListaSubjets)
                {
                    if (dummySubject.Teacher.Equals(subject.Teacher))
                    {
                        anterior = subject.Name;
                        subject.Name = txtBoxMateria;
                        Console.WriteLine($"Se ha actualizado la {txtBoxMateria}  ahora la imparte {txtBoxTeachear}");
                    }
                    else
                    {
                        Console.WriteLine($"No se ha localizado la asignatura {txtBoxMateria}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Los campos Materia y/o Teacher no contienen información o no es válida");
            }
            return anterior;                  
        }

        public static string DeleteSubject(string txtBoxMateria, string txtBoxTeachear) 
        {
            if (!string.IsNullOrWhiteSpace(txtBoxMateria) && !string.IsNullOrWhiteSpace(txtBoxTeachear))
            {
                //Borramos si coinciden los dos campos exactamente
                Subject dummySubject = new Subject(txtBoxMateria, txtBoxTeachear);
                ListaSubjets.Remove(dummySubject);
                //Borramos si coincide con la materia
                ListaSubjets.RemoveAll(x => x.Name.Equals(dummySubject.Name));
                Console.WriteLine("Subject borrada correctamente");
            }
            else
            {
                Console.WriteLine("Los campos Materia y/o Teacher no contienen información o no es válida");
                txtBoxTeachear = null;
            }
            return txtBoxMateria;
        }

        public static void ListSubjets()
        {
            int posicion = 1;
            foreach (Subject subjet in ListaSubjets)
            {
                Console.WriteLine($"{posicion}-) {subjet.Name} imparte: {subjet.Teacher}");
                posicion++;
            }
        }
        #endregion CRUDs Subjects

        #region CRUDS Exams

        public static string RegistrarNewExam(int indxAlumno, int indxMateria, DateTime timeStamp, double score)
        {

            var salida = "";
            Exam dummyExam = new Exam(DictionayStudents.ElementAt(indxAlumno).Value, ListaSubjets[indxMateria], timeStamp, score);
            var result = ListaExams.Where(x => x.Student.Name.Equals(dummyExam.Student.Name)
            && x.Subject.Name.Equals(dummyExam.Subject.Name) && x.DateTimeExam.Equals(dummyExam.DateTimeExam));
            if (result != null && result.Count() > 0)
            {
                salida = "SOS este alumno ya ha realizado este examen en la misma fecha";

            }
            else
            {
                ListaExams.Add(dummyExam);
                salida = "Examen guardado correctamente";
            }
            return salida;
        }


        public static string UpdateExam(int indxAlumno, int indxMateria, DateTime timeStamp, string notaTexto) 
        {
            Student dummyStudent = DictionayStudents.ElementAt(indxAlumno).Value;
            Subject dummySubject = ListaSubjets[indxMateria];

            var salida = "";
            if ((indxAlumno >= 0) && (indxMateria >= 0)
               && !string.IsNullOrWhiteSpace(notaTexto) && double.TryParse(notaTexto, out var score)
               && (timeStamp != null))
            {
                Exam dummyExam = new Exam(dummyStudent, dummySubject, timeStamp, score);

                foreach (Exam exam in ListaExams)
                {
                    if (exam.Student.Equals(dummyStudent) && exam.Subject.Equals(dummySubject)
                        && exam.DateTimeExam.Equals(timeStamp))
                    {
                        salida = $"Se ha actualizado la nota a {dummyStudent.Name}   por el profesor {dummySubject.Teacher}";
                        exam.Score = score;
                    }
                    else
                    {
                        salida = $"No se ha localizado el examen de la materia " +
                            $"{dummySubject.Name} para {dummyStudent.Name}." +
                            $" Si quiere lo puede dar de alta clicando en Add Exam ";
                    }
                }
            }
            else
            {
                salida= "Falta informar algún campo o la información no es válida";
            }
            return salida;
        }


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
                ListaExams.RemoveAll(x => x.Student.Equals(dummyStudent) && x.Subject.Equals(dummySubject)
                && x.DateTimeExam.Equals(timeStamp));
                salida = "Examen borrado correctamente";
            }
            else
            {
                salida = "La información introducada no corresponde con ningún examen";
            }
            return salida;
        }

        public static string ListExams() 
        {
            var salida = "";
            int posicion = 1;
            foreach (Exam exam in ListaExams)
            {
                salida += $"{posicion}-) El día {exam.DateTimeExam} el alumno {exam.Student.Name} en la materia {exam.Subject.Name}, ha obtenido una nota de {exam.Score}";
                posicion++;
            }
            return salida;
        }
           


        #endregion CRUDS Exams
    }
}
