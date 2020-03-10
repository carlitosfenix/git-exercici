using CSharp_5_2.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp_5_2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Previo a Model
        /**
         * Previo a model
         */
        double NotaAlumno;
        string KeyWordOut = "runyoufools";

        /**
         * Versión previa al modelo
         */
        private void BtnRegistrarNota_Click(object sender, RoutedEventArgs e)
        {
            RegistrarAlumno();

        }

        /**
         * Versión previa al modelo
         */
        private void RegistrarAlumno()
        {
            RegistroAlumnos MiRegistroAlumnos = new RegistroAlumnos();
            var notaAlumno = txtBoxNota.Text;
            if (string.IsNullOrEmpty(notaAlumno) || double.TryParse(notaAlumno, out NotaAlumno))
            {
                if (!notaAlumno.Equals(KeyWordOut))
                {
                    // TODO: por ahora no se usa , crear dictionay para
                    // guardar (string double) txtBoxNombre              
                    MiRegistroAlumnos.RegistrarAlumno(NotaAlumno);
                }
                else
                {
                    btnRegistrarNewExam.IsEnabled = false;
                    MiRegistroAlumnos.CalcularMaxMedMin();

                }
            }
        }
        #endregion Previo model


        List<Student> ListaStudents = new List<Student>();
        List<Subject> ListaSubjets = new List<Subject>();
        List<Exam> ListaExams = new List<Exam>();
        bool TenemosAlumno = false;
        bool TenemosMateria = false;

        public MainWindow()
        {
            InitializeComponent();
            //Cuando tengamos un alumno y una materia lo podndremos activo
            OcultarCRUDSExamenes();

        }

        public void OcultarCRUDSExamenes()
        {
            btnRegistrarNewExam.IsEnabled = false;
            btnUpdateExam.IsEnabled = false;
            btnDeleteExam.IsEnabled = false;
            btnListListExams.IsEnabled = false;
        }

        public void MostrarCRUDSExamenes()
        {
            btnRegistrarNewExam.IsEnabled = true;
            btnUpdateExam.IsEnabled = true;
            btnDeleteExam.IsEnabled = true;
            btnListListExams.IsEnabled = true;
        }

        #region CRUDS Student
        /**
         * Alta new Alumno insert into
         */
        private void btnRegistrarNewStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxNombre.Text) && !string.IsNullOrWhiteSpace(txtBoxDni.Text))
            {
                Student dummyStudent = new Student(txtBoxNombre.Text, txtBoxDni.Text);
               var result= ListaStudents.Where(x => x.Dni.Equals(txtBoxDni.Text));
                if (result!=null && result.Count()>0) {
                    Console.WriteLine("SOS hay otro alumno con este dni");

                }
                else
                {
                    ListaStudents.Add(dummyStudent);
                    Console.WriteLine("Alumno guardado correctamente");
                    addStudentToComboBox(dummyStudent);
                }
                
            }
            else
            {
                Console.WriteLine("Los campos Nombre y/o DNI no contienen información o no es válida");
            }

        }
        /**
         * Update Alumno
         */
        private void btnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxNombre.Text) && !string.IsNullOrWhiteSpace(txtBoxDni.Text))
            {
                Student dummyStudent = new Student(txtBoxNombre.Text, txtBoxDni.Text);
                foreach (Student student in ListaStudents)
                {
                    if (txtBoxDni.Text.Equals(txtBoxDni.Text))
                    {
                        student.Name = txtBoxNombre.Text;
                        Console.WriteLine($"Se ha actualizado el nombre del alumno con dni {txtBoxDni.Text}");
                    }
                    else
                    {
                        Console.WriteLine($"No se ha localizado ningún alumno con el {txtBoxDni.Text}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Los campos Nombre y/o DNI no contienen información o no es válida");
            }

        }

        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxNombre.Text) && !string.IsNullOrWhiteSpace(txtBoxDni.Text))
            {
                //Borramos si coinciden los dos campos exactamente
                Student dummyStudent = new Student(txtBoxNombre.Text, txtBoxDni.Text);
                ListaStudents.Remove(dummyStudent);
                //Borramos si coincide el DNI
                ListaStudents.RemoveAll(x => x.Dni.Equals(dummyStudent.Dni));
                Console.WriteLine("Alumno borrado correctamente");
            }
            else
            {
                Console.WriteLine("Los campos Nombre y/o DNI no contienen información o no es válida");
            }


          
          

        }

        private void btnListStudents_Click(object sender, RoutedEventArgs e)
        {
            int posicion = 1;
            foreach (Student student in ListaStudents)
            {
                Console.WriteLine($"{posicion}-) {student.Name} con DNI: {student.Dni}");
                posicion++;
            }
        }
        #endregion CRUDS Student


        #region CRUDS Subject
        private void btnRegistrarNewSubject_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxMateria.Text) && !string.IsNullOrWhiteSpace(txtBoxTeachear.Text))
            {
                Subject dummySubject = new Subject(txtBoxMateria.Text, txtBoxTeachear.Text);
                var result = ListaSubjets.Where(x => x.Name.Equals(txtBoxMateria.Text));
                if (result != null && result.Count() > 0)
                {
                    Console.WriteLine($"SOS esa materia ya la imparte {result.First().Teacher}");

                }
                else
                {
                    ListaSubjets.Add(dummySubject);
                    Console.WriteLine($"Materia {dummySubject.Name} impartida por {dummySubject.Teacher}, guardada correctamente");
                    addSubjectToComboBox(dummySubject);
                }

            }
            else
            {
                Console.WriteLine("Los campos Subject y/o Teacher no contienen información o no es válida");
            }

        }

        private void btnUpdateSubject_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxMateria.Text) && !string.IsNullOrWhiteSpace(txtBoxTeachear.Text))
            {
                Subject dummySubject = new Subject(txtBoxMateria.Text, txtBoxTeachear.Text);
                foreach (Subject subject in ListaSubjets)
                {
                    if (txtBoxDni.Text.Equals(txtBoxDni.Text))
                    {
                        subject.Name = txtBoxMateria.Text;
                        Console.WriteLine($"Se ha actualizado la {txtBoxMateria.Text}  ahora la imparte {txtBoxTeachear.Text}");
                    }
                    else
                    {
                        Console.WriteLine($"No se ha localizado la asignatura {txtBoxMateria.Text}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Los campos Materia y/o Teacher no contienen información o no es válida");
            }
        }

        private void btnDeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxMateria.Text) && !string.IsNullOrWhiteSpace(txtBoxTeachear.Text))
            {
                //Borramos si coinciden los dos campos exactamente
                Subject dummySubject = new Subject(txtBoxMateria.Text, txtBoxTeachear.Text);
                ListaSubjets.Remove(dummySubject);
                //Borramos si coincide con la materia
                ListaSubjets.RemoveAll(x => x.Name.Equals(dummySubject.Name));
                Console.WriteLine("Subject borrada correctamente");
            }
            else
            {
                Console.WriteLine("Los campos Materia y/o Teacher no contienen información o no es válida");
            }
        }

        private void btnListListSubjects_Click(object sender, RoutedEventArgs e)
        {
            int posicion = 1;
            foreach (Subject subject in ListaSubjets)
            {
                Console.WriteLine($"{posicion}-) {subject.Name} con el Profesor: {subject.Teacher}");
                posicion++;
            }

        }
        #endregion CRUDS Subject

        #region Auxiliares ComboBox

        private int addStudentToComboBox(Student dummyStudent)
        {
            var cuenta=comboBoxAlumno.Items.Add(dummyStudent.Name);
            TenemosAlumno = true;
            if (TenemosMateria) btnRegistrarNewExam.IsEnabled = true;
            return cuenta;
        }

        private int addSubjectToComboBox(Subject dummySubject)
        {
            var cuenta =  comboBoxAsignatura.Items.Add(dummySubject.Name);
            TenemosMateria = true;
            if (TenemosAlumno) btnRegistrarNewExam.IsEnabled = true;
            return cuenta;
        }
        #endregion


        #region CRUDS Exams

      

        private void btnRegistrarNewExam_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBoxAlumno.SelectedIndex>=0) && (comboBoxAsignatura.SelectedIndex>=0)
               && !string.IsNullOrWhiteSpace(txtBoxNota.Text) && double.TryParse(txtBoxNota.Text, out var score))
            {
               ;
                var indxAlumno = comboBoxAlumno.SelectedIndex;
                var indxMateria = comboBoxAsignatura.SelectedIndex;

                DateTime timeStamp = calExam.SelectedDate.Value.Date;
                Exam dummyExam = new Exam(ListaStudents[indxAlumno],ListaSubjets[indxMateria],timeStamp,score);
                var result = ListaExams.Where(x => x.Student.Name.Equals(ListaStudents[indxAlumno].Name) 
                && x.Subject.Name.Equals(ListaSubjets[indxMateria].Name));
                if (result != null && result.Count() > 0)
                {
                    Console.WriteLine("SOS este alumno ya ha realizado este examen");

                }
                else
                {
                    ListaExams.Add(dummyExam);
                    Console.WriteLine("Examen guardado correctamente");
                 
                }

            }
            else
            {
                Console.WriteLine("Los campos Puntuacion y/o otros no contienen información o no es válida");
            }


            MostrarCRUDSExamenes();
        }

        private void btnUpdateExam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteExam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListListExams_Click(object sender, RoutedEventArgs e)
        {
            int posicion = 1;
            foreach (Exam exam in ListaExams)
            {
                Console.WriteLine($"{posicion}-) el alumno {exam.Student.Name} en la materia {exam.Student.Name}, ha obtenido una nota de {exam.Score}");
                posicion++;
            }

        }

        #endregion CRUDS Exams



    }
}
