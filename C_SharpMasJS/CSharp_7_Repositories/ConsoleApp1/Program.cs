using Academy.Lib.Context;
using Academy.Lib.Infrastructure;
using Academy.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ConsoleApp1
{
    class Program
    {
        static string OpcionActual;
        static string nomMenu;
        static readonly string Separador = "-----------------------------------------";


        public static StudentRepository StudentRepository { get; set; }
        public static SubjectRepository SubjectRepository { get; set; }
        public static ExamRepository ExamRepository { get; set; }

        static void Main(string[] args)
        {
            StudentRepository = new StudentRepository();
            SubjectRepository = new SubjectRepository();
            ExamRepository   = new ExamRepository();
            Presentacion();
        }

        private static void Presentacion()
        {
            DatosdParaPruebas();
            MenuPrincipal();
            ControlDeFlujoPrincipal();
        }


        private static void DatosdParaPruebas()
        {
            AlumnoAltaPruebas("44000041Y", "Antonio Raro Raro", "1");
            AlumnoAltaPruebas("12345678Z", "Milano Reo Feo", "2");
            //Para verificar validations
            AlumnoAltaPruebas("44000041Y", "Antonio Raro Raro", "1");
            AlumnoAltaPruebas("44000041Z", "Antonio Raro Raro", "2");
            /*
            DbContext.RegistrarNewSubject("SQL", "Miguel Raro Palo");
            DbContext.RegistrarNewSubject("GIT", "Andrés Raro Palo");
            Student antonio = DbContext.SelectStudentByDNI("44000041Y");
            Subject sql = DbContext.SelectSubjetByName("SQL");
            DbContext.RegistrarNewExam(antonio, sql, DateTime.Now, 6.6);
            DbContext.RegistrarNewExam(DbContext.SelectStudentByDNI("12345678Z"), DbContext.SelectSubjetByName("GIT"), DateTime.Now, 8.8);
            DbContext.RegistrarNewExam(DbContext.SelectStudentByDNI("12345678Z"), DbContext.SelectSubjetByName("SQL"), DateTime.Now, 5.6);*/
        }

        private static void MenuPrincipal()
        {
            LimpiarPantallaTMP();
            Console.WriteLine("GETIÓN ALUMNOS -VERSIÓN UI CONSOLE-");
            Console.WriteLine(Separador);
            OpcionActual = "p";
            nomMenu = "Principal";
            Console.WriteLine(Separador);
            Console.WriteLine("1) Menú principal");
            Console.WriteLine(Separador);
            Console.WriteLine("Opción: p - volver a Este Menú");
            Console.WriteLine("Opción: a - gestión de Alumnos");
            Console.WriteLine("Opción: m - gestión de Materias");
            Console.WriteLine("Opción: e - gestión de Exámenes");
            Console.WriteLine("Opción: s - Estadísticas");
            Console.WriteLine("Opción: q - Salir de la App");
        }

        private static void ControlDeFlujoPrincipal()
        {
            var continuar = true;
            while (continuar)
            {
                LimpiarConsoleLine();
                var option = Console.ReadKey().KeyChar;


               switch (option)
                {

                    case 'p':
                        if (!OpcionActual.Equals("p"))
                        {
                            MenuPrincipal();
                        }
                        break;
                    case 'a':
                        MenuAlumnos();
                        break;
                    case 'm':
                        MenuMaterias();
                        break;
                    case 'e':
                        MenuExamenes();
                        break;
                    case 's':
                        //TODO: MenuEstadisticas();
                        break;
                    case 'q':
                        continuar = false;
                        break;
                }
            }
        }

        #region Flujo y llamadas a SubjectRepository
        private static void MenuAlumnos()
        {
            OpcionActual = "a";
            nomMenu = "Alumnos";
            LimpiarPantallaTMP();
            Console.WriteLine(Separador);
            Console.WriteLine("2) Menu para la gestión de alumnos.");
            Console.WriteLine(Separador);
            Console.WriteLine("Opción: a - para añadir un nuevo almuno");
            Console.WriteLine("Opción: e + dni - para editar un alumno existente");
            Console.WriteLine("Opción: i + dni - ver información del alumno con examenes");
            Console.WriteLine("Opción: d + dni - Borrar Alumno");
            Console.WriteLine("Opción: l - listar alumnos");
            Console.WriteLine("Presione 'p' para acabar y volver al menú principal");
            ControlDeFlujoAlumnos();
        }

        static void ControlDeFlujoAlumnos()
        {
            var continuar = true;
            while (continuar)
            {
                var option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case 'p':
                        continuar = false;
                        break;
                    case 'a':
                        AlumnoAlta();
                        break;
                    case 'e':
                        AlumnoEdicion();
                        break;
                    case 'i':
                        AlumnoInformacion();
                        break;
                    case 'd':
                        AlumnoBaja();
                        break;
                    case 'l':
                        AlumnosListado();
                        break;
                }
                LimpiarConsoleLine();
                if (option.Equals('*'))
                {
                    OpcionNoGuardar();
                }
            }
            MenuPrincipal();
        }

        private static void AlumnoBaja()
        {
            LimpiarConsoleLine();
            Console.WriteLine($"2 - 4) Baja de Alumno. de {nomMenu}");
            Console.WriteLine("Para volver sin eliminar alumno entra  *.");

            Console.WriteLine("entra el dni:");
            string bajaDni = Console.ReadLine();
            if (StudentRepository.GetStudentByDni(bajaDni) != null)
            {
                Student dummyStudent = StudentRepository.GetStudentByDni(bajaDni);

                var dR = StudentRepository.Delete(dummyStudent);


                if (dR.DeleteValidationSuccesful)
                {
                    Console.WriteLine("Alumno dado de baja");
                }
                else
                {
                    Console.WriteLine("No Borrado debido a errores");
                }
            }
            else
            {
                Console.WriteLine("Ninguna coincidencia con este dni!");
                Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");

            }

        }


        private static bool AlumnoAlta()
        {
            LimpiarConsoleLine();
            Console.WriteLine($"2 - 1) Alta de Alumno. de {nomMenu}");
            Console.WriteLine("Para volver sin guardar alumno entra  *.");

            Console.WriteLine("entra el dni:");
            var dni = "";
            bool primera = true;

            ValidationResult<string> vrDni = Student.ValidateDni(dni);

            do
            {
                if (!primera) Console.WriteLine(vrDni.AllErrors);
                dni = Console.ReadLine();
                if (dni == "*") return false;
                primera = false;
            } while (!(vrDni = Student.ValidateDni(dni)).IsSuccess);


            ValidationResult<string> vrName = EntradaNombre("entra el nombre y apellidos:");


            ValidationResult<int> vrChair = EntraNumSilla("entra el número de silla:");


            if (vrDni.IsSuccess && vrName.IsSuccess && vrChair.IsSuccess)
            {
                var student = new Student
                {
                    Dni = vrDni.ValidatedResult,
                    Name = vrName.ValidatedResult,
                    ChairNumber = vrChair.ValidatedResult
                };

                var sr = student.Save();
                var sr2 = StudentRepository.Add(student);
                if (sr.IsSuccess && sr2.IsSuccess)
                {
                    Console.WriteLine($"alumno guardado correctamente");
                    return true;
                }
                else
                {
                    Console.WriteLine($"uno o más errores han ocurrido y el alumno no se guardado/actualizado: {sr.AllErrors} {sr2.AllErrors}");
                    return false;
                }
            }
            return false;
        }

        private static bool AlumnoEdicion()
        {
            LimpiarConsoleLine();
            Console.WriteLine($"2 - 2) Edición de Alumno. de {nomMenu}");
            Console.WriteLine("Para volver sin guardar alumno entra  *.");
            Console.WriteLine("entra el dni del alumno a editar:");
            var dni = Console.ReadLine();
            var result = StudentRepository.GetStudentByDni(dni);
            if (result != null)
            {


                ValidationResult<string> vrName = EntradaNombre("entra nombre y apellidos correctos:");


                ValidationResult<int> vrChair = EntraNumSilla("entra el número de silla correcto:", result.Id);

                if (vrName.IsSuccess && vrChair.IsSuccess)
                {
                    Student editedStudent = new Student
                    {
                        Id = result.Id,
                        Dni = result.Dni,
                        Name = vrName.ValidatedResult,
                        ChairNumber = vrChair.ValidatedResult
                    };
                    StudentRepository.Update(editedStudent);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Ninguna coincidencia con este dni!");
                Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");
            }
            return false;
        }

        private static bool AlumnoInformacion()
        {
            LimpiarConsoleLine();
            Console.WriteLine($"2 - 3) Información de Alumno. de {nomMenu}");
            Console.WriteLine("Para ir hacia atrás entra  *.");
            Console.WriteLine("entra el dni del alumno a visualizar:");
            var dni = Console.ReadLine();
            var result = StudentRepository.GetStudentByDni(dni);
            if (result != null)
            {
                Console.WriteLine($"- {result.Name} con DNI: {result.Dni} y silla {result.ChairNumber}");
                //TODO: iterar examenes  
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("No hay coincidencia o todavía no hay alumnos.");
                Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }
            return true;
        }

        private static void AlumnosListado()
        {
            LimpiarConsoleLine();
            Console.WriteLine("2 - 5) Listado de Alumnos.");
            var dicStudentsByDNI = StudentRepository.GetAllStudents();
            if (dicStudentsByDNI.Count < 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Todavía no hay registrado ningún alumno.");
                Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");
            }
            else
            {
                int posicion = 1;
                foreach (Student student in dicStudentsByDNI.Values)
                {
                    Console.WriteLine($"{posicion}-) {student.Name} con DNI: {student.Dni} y silla {student.ChairNumber}");
                    posicion++;
                }
            }
        }
        #endregion Flujo y llamadas a SubjectRepository

        #region Flujo y llamadas a SubjectRepository para Materias
        private static void MenuMaterias()
        {
            OpcionActual = "m";
            nomMenu = "Materias";
            LimpiarPantallaTMP();
            Console.WriteLine(Separador);
            Console.WriteLine("3) Menú para la gestión de Materias.");
            Console.WriteLine(Separador);
            Console.WriteLine("Opción: a - para añadir una nueva Materia");
            Console.WriteLine("Opción: e - para editar una Materia Existente");
            Console.WriteLine("Opción: l - listar Materias");
            Console.WriteLine("Presione 'p' para acabar y volver al menú principal");
            ControlDeFlujoMaterias();
        }

        private static void ControlDeFlujoMaterias()
        {
            var continuar = true;
            while (continuar)
            {
                var option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case 'p':
                        continuar = false;
                        break;
                    case 'a':
                        MateriaAlta();
                        break;
                    case 'e':
                        MateriaEdicion();
                        break;
                    case 'l':
                        MateriasListado();
                        break;
                }
                LimpiarConsoleLine();
                if (option.Equals('*'))
                {
                    OpcionNoGuardar();
                }
            }
            MenuPrincipal();
        }

        private static bool MateriaAlta()
        {
            LimpiarConsoleLine();
            Console.WriteLine("3 - 1) Alta de Materia. Para volver al menú Materia en cualquier momento entra *.");
            Console.WriteLine("Entra el nombre de la materia:");
            Console.WriteLine("Para volver sin guardar asignatura escriba  *.");

            var name = "";
            bool primera = true;

            ValidationResult<string> vrName = Subject.ValidateName(name);
            do
            {
                if (!primera) Console.WriteLine(vrName.AllErrors);

                name = Console.ReadLine();
                if (name == "*") return false;
                primera = false;
            } while (!(vrName = Subject.ValidateName(name)).IsSuccess);


            Console.WriteLine("escriba el nombre del profesor:");

            var teacher = "";
            primera = true;

            ValidationResult<string> vrTeacher = Subject.ValidateTeacher(teacher);
            do
            {
                if (!primera) Console.WriteLine(vrTeacher.AllErrors);
                teacher = Console.ReadLine();
                if (teacher == "*") return false;
                primera = false;
            } while (!(vrTeacher = Subject.ValidateName(teacher)).IsSuccess);


            var subject = new Subject
            {
                Name = name,
                Teacher = teacher
            };


            var sr2 = SubjectRepository.Add(subject);
            if (sr2.IsSuccess && subject.Save().IsSuccess)
            {

                Console.WriteLine($"asignatura guardada correctamente");
                return true;
            }
            else
            {
                Console.WriteLine($"uno o más errores han ocurrido y la asignatura no se ha guardado correctamente");
            }


            return false;

        }

        private static bool MateriaEdicion()
        {
            LimpiarConsoleLine();
            Console.WriteLine("3 - 2) Edición de Materia. Para volver al menú Materia en cualquier momento entra *.");
            Console.WriteLine("Entra el nombre de la materia:");
            var name = Console.ReadLine();
            var result = SubjectRepository.GetSubjectByName(name);
            if (result != null)
            {
                Console.WriteLine("entra el profesor que corresponda a la materia:");
                var teacher = "";
                bool primera = true;

                ValidationResult<string> vrTeacher = Subject.ValidateTeacher(teacher);
                do
                {
                    if (!primera) Console.WriteLine(vrTeacher.AllErrors);
                    teacher = Console.ReadLine();
                    if (teacher == "*") return false;
                    primera = false;
                } while (!(vrTeacher = Subject.ValidateName(teacher)).IsSuccess);


                if (vrTeacher.IsSuccess)
                {
                    Subject editedSubject = new Subject
                    {
                        Name = name,
                        Teacher = teacher
                    };
                    SubjectRepository.Update(editedSubject);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Ninguna coincidencia con esta materia!");
                Console.WriteLine("¿Algo más del menú de materias?, en caso contrario entra 'p' para ir al menú principal.");
            }
            return false;
        }

        private static void MateriasListado()
        {
            LimpiarConsoleLine();
            Console.WriteLine("3 - 3) Listado de Materias.");
            var dicSubjectsByName = SubjectRepository.GetAllSubjects();
            if (dicSubjectsByName.Count < 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Todavía no hay registrada ninguna materia.");
                Console.WriteLine("¿Algo más del menú de materias?, en caso contrario entra 'p' para ir al menú principal.");
            }
            else
            {
                int posicion = 1;
                foreach (Subject subject in dicSubjectsByName.Values)
                {
                    Console.WriteLine($"{posicion}-) La materia {subject.Name} la imparte el maestro {subject.Teacher}");
                    posicion++;
                }
            }
        }

        #endregion Materias
        private static void MenuExamenes()
        {
            OpcionActual = "e";
            nomMenu = "Examenes";
            LimpiarPantallaTMP();
            Console.WriteLine(Separador);
            Console.WriteLine("4) Menú para la gestión de Exámenes.");
            Console.WriteLine(Separador);
            Console.WriteLine("Opción: a - para añadir una nuevo Examen");
            Console.WriteLine("Opción: e - para editar un Examen");
            Console.WriteLine("Opción: l - listar Examenes");
            Console.WriteLine("Presione 'p' para acabar y volver al menú principal");
            ControlDeFlujoExamenes();
        }

        private static void ControlDeFlujoExamenes()
        {
            var continuar = true;
            while (continuar)
            {
                var option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case 'p':
                        continuar = false;
                        break;
                    case 'a':
                        ExamenAlta();
                        break;
                    case 'e':
                        //TODO: ExamenEdicion();
                        break;
                    case 'l':
                        ExamenesListado();
                        break;
                }
                LimpiarConsoleLine();
                if (option.Equals('*'))
                {
                    OpcionNoGuardar();
                }
            }
            MenuPrincipal();
        }

        private static void ExamenesListado()
        {
            LimpiarConsoleLine();
            Console.WriteLine("4 - 3) Listado de Examen.");
            var dicExamsByDniDate = ExamRepository.GetAllExamns();
            if (dicExamsByDniDate.Count < 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Todavía no hay registrado ningún examen.");
                Console.WriteLine("¿Algo más del menú de exámenes?, en caso contrario entra 'p' para ir al menú principal.");
            }
            else
            {
                int posicion = 1;
                foreach (Exam exam in dicExamsByDniDate.Values)
                {
                    Console.WriteLine($"{posicion}-) El examen de {exam.Subject.Name} de fecha {exam.DateTimeExam}, impartido por {exam.Subject.Teacher}, realizado por {exam.Student.Name} obtuvo una nota de {exam.Score}");
                    posicion++;
                }
            }


        }

        private static bool ExamenAlta()
        {
            LimpiarConsoleLine();
            Console.WriteLine("4 - 1) Alta de Examen.");
            Console.WriteLine("Para volver sin guardar examen entra *.");
            Console.WriteLine("Entra la nota del examen:");
           
            var nota = "";
            bool primera = true;

            ValidationResult<double> vrNote = Exam.ValidateNote(nota);
            do
            {
                if (!primera) Console.WriteLine(vrNote.AllErrors);

                nota = Console.ReadLine();
                if (nota == "*") return false;
                primera = false;
            } while (!(vrNote = Exam.ValidateNote(nota)).IsSuccess);


            Console.WriteLine("La fecha, por ahora, será el timeStamp de Now.");
            DateTime date = DateTime.Now;
            primera = true;

            ValidationResult<DateTime> vrDate = Exam.ValidateDate(date);
            do
            {
                if (!primera) Console.WriteLine(vrDate.AllErrors);

                date = DateTime.Now;
               // if (date == "*") return false;
                primera = false;
            } while (!(vrDate = Exam.ValidateDate(date)).IsSuccess);

            Console.WriteLine("Entra el dni del alumno:");
            primera = true;
            var dni = "";
            ValidationResult<Student> vrAlumno = Exam.ValidateStudent(dni,primera);
  
            do
            {
                if (!primera) Console.WriteLine(vrAlumno.AllErrors);

                dni = Console.ReadLine();
                if (dni == "*") return false;
                primera = false;
             } while (!(vrAlumno = Exam.ValidateStudent(dni, primera)).IsSuccess);
           

            Console.WriteLine("Entra el nombre de la Materia:");
            var nameSubject = "";
            primera = true;

            ValidationResult<Subject> vrAsignatura = Exam.ValidateSubject(nameSubject, primera);
            do
            {
                if (!primera) Console.WriteLine(vrAsignatura.AllErrors);

                nameSubject = Console.ReadLine();
                if (nameSubject == "*") return false;
                primera = false;
            } while (!(vrAsignatura = Exam.ValidateSubject(nameSubject, primera)).IsSuccess);



            if (vrNote.IsSuccess && vrDate.IsSuccess && vrAlumno.IsSuccess && vrAsignatura.IsSuccess)
            {
                Exam dummySubject = new 
                    Exam(vrAlumno.ValidatedResult,
                    vrAsignatura.ValidatedResult, vrDate.ValidatedResult,
                    vrNote.ValidatedResult);

                var sr =ExamRepository.Add(dummySubject);
                if (sr.IsSuccess)
                {

                    Console.WriteLine($"examen guardado correctamente");
                    return true;
                }
                else
                {
                    Console.WriteLine($"uno o más errores han ocurrido y el examen no se ha guardado correctamente");
                }
                return true;

               
            }
            return false; ;
        }
      

        #region Exámenes



        #endregion Exámenes

        static void ShowAverage()
        {
            //var avg =  Marks.Values
            //                .SelectMany(x => x)
            //                .Where(x => x > 3)
            //                .Average();

            var avg = 0.0;
            Console.WriteLine($"La media actual es: {avg}");
            Console.WriteLine();
        }

        static void ShowMinimum()
        {
            Console.WriteLine("La nota más baja es: ");
            Console.WriteLine();
        }

        static void ShowMaximum()
        {
            Console.WriteLine("La nota más alta es: ");
            Console.WriteLine();
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        #region Formulas

        public static double GetAverage()
        {
            var sum = 0.0;

            //for (var i = 0; i < Marks.Count; i++)
            //{
            //    sum += Marks[i];
            //}

            //return sum / Marks.Count;
            return sum;
        }
        #endregion Formulas




        #region auxiliares
        private static void LimpiarConsoleLine()
        {
            //TODO: Ver como redibujamos el menú y últimas lineas
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private static void LimpiarPantallaTMP()
        {
            Console.Clear();
        }

        private static void OpcionNoGuardar()
        {
            Console.WriteLine("");
            Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");
        }

        private static bool AlumnoAltaPruebas(string dni, string name, string chairNumberText)
        {
            ValidationResult<string> vrDni;
            if (!(vrDni = Student.ValidateDni(dni)).IsSuccess)
            {
                Console.WriteLine(vrDni.AllErrors);
            }

            ValidationResult<string> vrName;
            if (!(vrName = Student.ValidateName(name)).IsSuccess)
            {
                Console.WriteLine(vrName.AllErrors);
            }

            ValidationResult<int> vrChair;
            if (!(vrChair = Student.ValidateChairNumber(chairNumberText)).IsSuccess)
            {
                Console.WriteLine(vrChair.AllErrors);
            }

            if (vrDni.IsSuccess && vrName.IsSuccess && vrChair.IsSuccess)
            {
                var student = new Student
                {
                    Dni = vrDni.ValidatedResult,
                    Name = vrName.ValidatedResult,
                    ChairNumber = vrChair.ValidatedResult
                };

                var sr = student.Save();
                var sr2 = StudentRepository.Add(student);
                if (sr.IsSuccess && sr2.IsSuccess)
                {
                    Console.WriteLine($"alumno guardado correctamente");
                    return true;
                }
                else
                {
                    Console.WriteLine($"uno o más errores han ocurrido y el almuno no se guardado/actualizado: {sr.AllErrors} {sr2.AllErrors}");
                }
            }
            return false;
        }

        private static ValidationResult<string> EntradaNombre(string mensajeNombre)
        {
            Console.WriteLine(mensajeNombre);
            var name = "";
            var primera = true;
            ValidationResult<string> vrName = Student.ValidateName(name);
            do
            {
                if (!primera) Console.WriteLine(vrName.AllErrors);
                name = Console.ReadLine();
                if (name == "*") return vrName;
                primera = false;
            } while (!(vrName = Student.ValidateName(name)).IsSuccess);
            return vrName;
        }

        private static ValidationResult<int> EntraNumSilla(string mensajeSilla, Guid id = default)
        {
            Console.WriteLine(mensajeSilla);
            var chairNumberText = "";
            var primera = true;
            ValidationResult<int> vrChair = Student.ValidateChairNumber(chairNumberText, id);
            do
            {
                if (!primera) Console.WriteLine(vrChair.AllErrors);
                chairNumberText = Console.ReadLine();
                if (chairNumberText == "*") return vrChair;
                primera = false;
            } while (!(vrChair = Student.ValidateChairNumber(chairNumberText, id)).IsSuccess);
            return vrChair;
        }


        #endregion auxialiares
    }

}