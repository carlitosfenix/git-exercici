using Academy.Lib.Context;
using Academy_4_DbContext.Lib.Model;
using System;


namespace CSharp_6_DbContext_Console
{
    class Program
    {
        static string OpcionActual;
        static string nomMenu;
        static readonly string Separador = "-----------------------------------------";
        static readonly string salir = "salir";

        static void Main(string[] args)
        {
            Presentacion();
        }

        static void Presentacion()
        {
            DatosdParaPruebas();
            MenuPrincipal();
            ControlDeFlujoPrincipal();
        }

        static void MenuPrincipal()
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

        static void ControlDeFlujoPrincipal()
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
                        MenuEstadisticas();
                        break;
                    case 'q':
                        continuar = false;
                        break;
                }
            }
        }
        #region Flujo y llamadas a DbContext para Alumnos
        static void MenuAlumnos()
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


        
        private static bool AlumnoAlta()
        {
            //FET: captura nombre y dni
            //FET: validacion
            //FET: si es correcto => persistir con DbContext
            var dni = ValidadarDNI("2 - 1) Alta de Alumno.",nomMenu);
            if (dni.Equals(salir)) return false;

            Console.WriteLine("Entra el nombre y apellidos:");
            var nombre = ValidarNombre();
            if (nombre.Equals("")) return false;

           //Versión anterior sin valete bool salida =(DbContext.RegistrarNewStudent(nombre, dni)==null)? false : true;
            Student student = new Student(nombre, dni);
            bool salida =  DbContext.SaveStudent(student).IsSuccess;
            return salida;
        }

        private static bool AlumnoEdicion()
        {
           
            var dni = ValidadarDNI("2 - 2) Edición de Alumno.",nomMenu);
            if (dni.Equals(salir)) return false;

            var selectedStudent = DbContext.SelectStudentByDNI(dni);
            if (selectedStudent == null)
            {
                Console.WriteLine("");
                Console.WriteLine("No hay coincidencia o todavía no hay alumnos.");
                Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }
            var nombreOld = selectedStudent.Name;

            Console.WriteLine($"El nombre actual es: {nombreOld}");
            Console.WriteLine("Entra la corrección para nombre y apellidos:");
            var nombre = ValidarNombre();
            
            bool salida =(DbContext.UpdateStudent(nombre, dni) =="") ? false : true;
            if (salida) Console.WriteLine("Actualización Corecta!");
            return salida;
        }



        private static bool AlumnoInformacion()
        {
            var dni = ValidadarDNI("2-3) Información.", nomMenu);
            if (dni.Equals(salir)) return false;
            var selectedStudent = DbContext.SelectStudentByDNI(dni);
            if (selectedStudent == null)
            {
                Console.WriteLine("");
                Console.WriteLine("No hay coincidencia o todavía no hay alumnos.");
                Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }

            string listExamens = DbContext.ListExamsAlumno(selectedStudent);
            string textAnunExa;
            if (listExamens.Equals(""))
            {
                textAnunExa = "todavía no tiene exámenes registrados. ";
            }
            else
            {
                textAnunExa = "ha realizado los examenes: ";
            }

            Console.WriteLine($"El Alumno {selectedStudent.Name} con el DNI {selectedStudent.Dni} {textAnunExa} ");
            Console.WriteLine(listExamens);
            return true;
        }

        private static bool AlumnoBaja()
        {
            var dni = ValidadarDNI("2-4) Baja.", nomMenu);
            if (dni.Equals(salir)) return false;
            var selectedStudent = DbContext.SelectStudentByDNI(dni);
            if (selectedStudent == null)
            {
                Console.WriteLine("");
                Console.WriteLine("No hay coincidencia o todavía no hay alumnos.");
                Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }

            DbContext.DeleteStudent(selectedStudent.Name, selectedStudent.Dni);
            return true;
        }

        private static void AlumnosListado()
        {
            LimpiarConsoleLine();
            Console.WriteLine("2 - 5) Listado de Alumnos.");
            var numItems = DbContext.ListStudents();
            if (numItems == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Todavía no hay registrado ningún alumno.");
                Console.WriteLine("¿Algo más del menú de alumno?, en caso contrario entra 'p' para ir al menú principal.");
            }
        }
        #endregion Flujo y llamadas a DbContext para Alumnos

        #region Flujo y llamadas a DbContext para Materias
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

            var subject = ValidarNomOrTeacher();
            if (subject.Equals("")) return false;

            Console.WriteLine("Entra el nombre del profesor que imparte la materia:");
            var nombre = ValidarNombre();
            if (nombre.Equals("")) return false;

            bool salida = (DbContext.RegistrarNewSubject(subject, nombre) == null) ? false : true;
            return salida;       
        }

        private static bool MateriaEdicion()
        {
            LimpiarConsoleLine();
            Console.WriteLine("3 - 2) Edición de Materia. Para volver al menú Materia en cualquier momento entra *.");
            Console.WriteLine("Entra el nombre de la materia:");
        
            var subject = ValidarNomOrTeacher();
            if (subject.Equals("")) return false;

            Console.WriteLine("Entra el nombre del nuevo profesor que imparte la materia:");
            var nombre = ValidarNombre();
            if (nombre.Equals("")) return false;

            if (DbContext.UpdateSubject(subject, nombre).Equals(""))
            {
                Console.WriteLine("No se ha localizado la mlateria.");
            }
            else
            {
              Console.WriteLine("Actualización Corecta!");
            }
            return true;
        }

        private void MateriaBaja()
        {
           // DbContext.DeleteSubject(txtBoxMateria.Text, txtBoxTeachear.Text);
        }

        private static bool MateriasListado()
        {
            LimpiarConsoleLine();
            Console.WriteLine("3 - 3) Listado de Materias y Maestros.");
            var numItems =  DbContext.ListSubjets();
            if (numItems == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Todavía no hay registrado ninguna Materia.");
                Console.WriteLine("¿Algo más del menú de Materia?, en caso contrario entra 'p' para ir al menú principal.");
            }
            return true;
        }
        #endregion Flujo y llamadas a DbContext para Materias


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
                        ExamenEdicion();
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

        private static bool ExamenAlta()
        {
            LimpiarConsoleLine();
            var dni = ValidadarDNI("4 - 1) Alta de Examen.", nomMenu);
            if (dni.Equals(salir)) return false;

            var selectedStudent = DbContext.SelectStudentByDNI(dni);
            if (selectedStudent == null)
            {
                Console.WriteLine("");
                Console.WriteLine(" Tadavía no hay registros para este DNI.");
                Console.WriteLine("¿Algo más del menú de Exámenes?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }

            Console.WriteLine("Entra el nombre de la materia del Examen:");
            var nomSubject = ValidarNomOrTeacher();
            if (nomSubject.Equals("")) return false;
            Subject subject =DbContext.SelectSubjetByName(nomSubject);
            if (subject == null)
            {
                Console.WriteLine("");
                Console.WriteLine(" Tadavía no está registrada esta Materia.");
                Console.WriteLine("¿Algo más del menú de Exámenes?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }

            Console.WriteLine("Entra la nota obtenida:");
            var score = ValidarNota();
            if (score < 0) return false;

            //TODO: en proxima versión hacer entrada y validación por console, para wpf ya está realizada
            DateTime dateTime = DateTime.Now;

            string  salida = DbContext.RegistrarNewExam(selectedStudent, subject, dateTime, score);
            Console.WriteLine(salida);
            return true;
        }

        private static bool ExamenEdicion()
        {
            LimpiarConsoleLine();
            var dni = ValidadarDNI("4 - 2) Edición de Examen.", nomMenu);
            if (dni.Equals(salir)) return false;

            var selectedStudent = DbContext.SelectStudentByDNI(dni);
            if (selectedStudent == null)
            {
                Console.WriteLine("");
                Console.WriteLine(" Tadavía no hay registros para este DNI.");
                Console.WriteLine("¿Algo más del menú de Exámenes?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }

            Console.WriteLine("Entra el nombre de la materia del Examen:");
            var nomSubject = ValidarNomOrTeacher();
            if (nomSubject.Equals("")) return false;
            Subject subject = DbContext.SelectSubjetByName(nomSubject);
            if (subject == null)
            {
                Console.WriteLine("");
                Console.WriteLine(" Tadavía no está registrada esta Materia.");
                Console.WriteLine("¿Algo más del menú de Exámenes?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }

            Console.WriteLine("Entra la corrección de la nota obtenida:");
            var score = ValidarNota();
            if (score < 0) return false;

            //TODO: en proxima versión hacer entrada y validación por console, para wpf ya está realizada
            DateTime dateTime = DateTime.Now;

            var salida = DbContext.UpdateExam(selectedStudent, subject, dateTime, score);
            Console.WriteLine(salida);
            return true;
        }

        private void ExamenBaja()
        {
            // DbContext.DeleteSubject(txtBoxMateria.Text, txtBoxTeachear.Text);
        }

        private static bool ExamenesListado()
        {
            LimpiarConsoleLine();
            Console.WriteLine("4 - 3) Listado de Examenes.");
            var listado = DbContext.ListExamsTodos();
            if (listado.Equals(""))
            {
                Console.WriteLine("");
                Console.WriteLine("Todavía no hay registrado ningún Examen.");
                Console.WriteLine("¿Algo más del menú de Exámenes?, en caso contrario entra 'p' para ir al menú principal.");
                return false;
            }
            Console.WriteLine(listado);
            return true;
        }

        private static void MenuEstadisticas()
        {
            LimpiarConsoleLine();
            Console.WriteLine(Separador);
            Console.WriteLine("Las Estadisticas SON:");
            Console.WriteLine(Separador);
            DbContext.CalcularMaxMedMin();
        }

        private static void ControlDeFlujoEstadisticas()
        {
            throw new NotImplementedException();
        }


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

        #region subMétodos comunes Alumno
        private static string ValidadarDNI(string numOpcion, string menu)
        {
            LimpiarConsoleLine();
            Console.WriteLine($"{numOpcion} Para volver al menú de {menu} en cualquier momento entra *.");
            Console.WriteLine("Entra el DNI correspondiente o *:");
            string dni = "";
            while (Student.ValidarDNI(dni) != Student.ResultDNI.Correcto)
            {
                dni = Console.ReadLine();
                if (dni.Contains("*"))
                {
                    OpcionNoGuardar();
                    return salir;
                }
                Student.ResultDNI resultado = Student.ValidarDNI(dni);
                LimpiarConsoleLine();
                var salida = "Revise el DNI, ";
                switch (resultado)
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
                Console.WriteLine(salida);

            }
            return dni;
        }

        private static string ValidarNombre()
        {
            var nombre = "";
            nombre = Console.ReadLine();
            if (nombre.Contains("*"))
            {
                OpcionNoGuardar();
                return "";
            }
            while (!Student.ValidarNombre(nombre))
            {
                Console.WriteLine("Revise el formato del nombre. Nombre y dos apellidos, por favor:");
                nombre = Console.ReadLine();
            }
            return nombre;
        }

        #endregion subMétodos comunes Alumno

        private static string ValidarNomOrTeacher()
        {
            var nombre = "";
          
           
            while (!Subject.ValidarNomOrTeacher(nombre))
            {
                Console.WriteLine("Debe de tener una longitud de entre 3 y 19, por favor.");
                nombre = Console.ReadLine();
                if (nombre.Contains("*"))
                {
                    OpcionNoGuardar();
                    return "";
                }
            }
            return nombre;
        }

        private static double ValidarNota() 
        {
            var score = "100";
            while (Exam.ValidarNota(score)==-1)
            {
                Console.WriteLine("Debe de ser una valor de 0 a 10, por favor.");
                score = Console.ReadLine();
                if (score.Contains("*"))
                {
                    OpcionNoGuardar();
                    return -1;
                }
            }
            return Exam.ValidarNota(score);

        }


        private static void DatosdParaPruebas()
        {
            Student stdAntonio = new Student("Antonio Raro Raro", "44000041Y");
            DbContext.SaveStudent(stdAntonio);
            Student stdMilano = new Student("Milano Reo Feo", "12345678Z");
            DbContext.SaveStudent(stdMilano);
            DbContext.RegistrarNewSubject("SQL", "Miguel Raro Palo");
            DbContext.RegistrarNewSubject("GIT", "Andrés Raro Palo");
            Student antonio = DbContext.SelectStudentByDNI("44000041Y");
            Subject sql = DbContext.SelectSubjetByName("SQL");
            DbContext.RegistrarNewExam(antonio,sql, DateTime.Now,6.6);
            DbContext.RegistrarNewExam(DbContext.SelectStudentByDNI("12345678Z"), DbContext.SelectSubjetByName("GIT"), DateTime.Now, 8.8);
            DbContext.RegistrarNewExam(DbContext.SelectStudentByDNI("12345678Z"), DbContext.SelectSubjetByName("SQL"), DateTime.Now, 5.6);


            /* Console.WriteLine((int)'a');   //Prints "97"
             Console.WriteLine((char)97);   //Prints "a"
             var opciones = "pamesq";
             var option = 'c';
             if (opciones.IndexOf(option) > -1)
             {

             }
             else
             {
                 Console.Write(new string(' ', Console.WindowWidth));
             }*/
        }
    }




}
