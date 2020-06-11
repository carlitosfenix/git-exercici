using Academy.Lib.Context;
using Academy_4_DbContext.Lib.Model;
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

namespace B1_WPF_MVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static AllRepositories RepoDb;
        List<Student> Students;
        List<Subject> Subjets;
        List<Exam> Exams;
        public MainWindow()
        {
            InitializeComponent();

            //Instancia al REpositorio que se encarga de llamar y gestionar la persistencia
            RepoDb = new AllRepositories();
            //Activamos botones CRUDS según el contenido en persistencia
            OpcionesIniciales();


        }



        #region Botones llamadas a CRUDS Student
        /**
         * Alta new Alumno, insert into
         */
        private void btnRegistrarNewStudent_Click(object sender, RoutedEventArgs e)
        {
            Student dummyStudent = new Student(txtBoxNombre.Text, txtBoxDni.Text);
            var cuenta = AddStudentToComboBox(RepoDb.SaveStudent(dummyStudent).IsSuccess, txtBoxNombre.Text);
            if (RepoDb.TenemosAlumno) MostrarCRUDSStudents();
        }


        private void btnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            UpdateStudentToComboBox(RepoDb.UpdateStudent(txtBoxNombre.Text, txtBoxDni.Text), txtBoxNombre.Text);
        }


        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudentToComboBox(RepoDb.DeleteStudent(txtBoxNombre.Text, txtBoxDni.Text));
        }


        private void btnListStudents_Click(object sender, RoutedEventArgs e)
        {
            RepoDb.ListStudents();
        }
        #endregion Botones llamadas a  CRUDS Student


        #region Botones llamadas a  CRUDS Subject
        private void btnRegistrarNewSubject_Click(object sender, RoutedEventArgs e)
        {
            var cuenta = AddSubjectToComboBox(RepoDb.RegistrarNewSubject(txtBoxMateria.Text, txtBoxTeachear.Text));
            if (cuenta >= 0) MostrarCRUDSSubjets();
        }


        private void btnUpdateSubject_Click(object sender, RoutedEventArgs e)
        {
            UpdateSubjectToComboBox(RepoDb.UpdateSubject(txtBoxMateria.Text, txtBoxTeachear.Text), txtBoxMateria.Text);
        }


        private void btnDeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            DeleteSbujectToComboBox(RepoDb.DeleteSubject(txtBoxMateria.Text, txtBoxTeachear.Text));
        }


        private void btnListListSubjects_Click(object sender, RoutedEventArgs e)
        {
            RepoDb.ListSubjets();
        }
        #endregion CRUDS Subject

        #region Auxiliares ComboBox


        private int PersistenceToStudentComboBox()
        {
            var cuenta = 0;
            foreach (Student student in Students)
            {
                cuenta = comboBoxAlumno.Items.Add(student.Name);
            }
            return cuenta;
        }

        private int PersistenceToSubjectComboBox()
        {
            var cuenta = 0;
            foreach (Subject subject in Subjets)
            {
                cuenta = comboBoxAsignatura.Items.Add(subject.Name);
            }
            return cuenta;
        }

        private int AddStudentToComboBox(bool addOK, string name)
        {
            var cuenta = 0;
            if (addOK)
            {
                cuenta = comboBoxAlumno.Items.Add(name);
                RepoDb.TenemosAlumno = true;
                if (RepoDb.TenemosMateria) btnRegistrarNewExam.IsEnabled = true;
            }
            return cuenta;
        }

        private int UpdateStudentToComboBox(string anterior, string actual)
        {
            var cuenta = 0;
            if (anterior != null && actual != null)
            {
                cuenta = comboBoxAlumno.Items.IndexOf(anterior);
                comboBoxAlumno.Items[cuenta] = actual;
            }
            return cuenta;
        }

        private int DeleteStudentToComboBox(string name)
        {
            var cuenta = 0;
            if (name != null)
            {
                cuenta = comboBoxAlumno.Items.IndexOf(name);
                comboBoxAlumno.Items.RemoveAt(cuenta);
            }


            return cuenta;

        }

        private int AddSubjectToComboBox(Subject dummySubject)
        {
            var cuenta = 0;
            if (dummySubject != null)
            {
                cuenta = comboBoxAsignatura.Items.Add(dummySubject.Name);
                RepoDb.TenemosMateria = true;
                if (RepoDb.TenemosAlumno) btnRegistrarNewExam.IsEnabled = true;
            }
            return cuenta;
        }

        private int UpdateSubjectToComboBox(string anterior, string actual)
        {
            var cuenta = 0;
            if (anterior != null && actual != null)
            {
                cuenta = 0;
                if (anterior != null && actual != null)
                {
                    cuenta = comboBoxAsignatura.Items.IndexOf(anterior);
                    comboBoxAsignatura.Items[cuenta] = actual;
                }
            }
            return cuenta;
        }

        private int DeleteSbujectToComboBox(string name)
        {
            var cuenta = 0;
            if (name != null)
            {
                cuenta = comboBoxAsignatura.Items.IndexOf(name);
                comboBoxAsignatura.Items.RemoveAt(cuenta);
            }


            return cuenta;
        }
        #endregion


        #region Botones llamadas a CRUDS Exams



        private void btnRegistrarNewExam_Click(object sender, RoutedEventArgs e)
        {
            var salida = "";
            if ((comboBoxAlumno.SelectedIndex >= 0) && (comboBoxAsignatura.SelectedIndex >= 0)
               && !string.IsNullOrWhiteSpace(txtBoxNota.Text) && double.TryParse(txtBoxNota.Text, out var score)
               && (calExam.SelectedDate.Value.Date != null))
            {

                //TODO:   salida = RepoDb.RegistrarNewExam(comboBoxAlumno.SelectedIndex, comboBoxAsignatura.SelectedIndex, calExam.SelectedDate.Value.Date, score);
                if (salida.StartsWith("Examen guardado")) MostrarCRUDSExamenes();

            }
            else
            {
                salida = "Los campos Puntuacion y/o otros no contienen información o no es válida";
            }

            Console.WriteLine(salida);
        }



        private void btnUpdateExam_Click(object sender, RoutedEventArgs e)
        {
            var indxAlumno = comboBoxAlumno.SelectedIndex;
            var indxMateria = comboBoxAsignatura.SelectedIndex;
            DateTime timeStamp = calExam.SelectedDate.Value.Date;
            var notaTexto = txtBoxNota.Text;

            //TODO: var salida = RepoDb.UpdateExam(indxAlumno, indxMateria, timeStamp, notaTexto);
            Console.WriteLine("TODO");
        }

        private void btnDeleteExam_Click(object sender, RoutedEventArgs e)
        {
            var indxAlumno = comboBoxAlumno.SelectedIndex;
            var indxMateria = comboBoxAsignatura.SelectedIndex;
            DateTime timeStamp = calExam.SelectedDate.Value.Date;
            var notaTexto = txtBoxNota.Text;

            //TODO: var salida = RepoDb.DeleteExam(indxAlumno, indxMateria, timeStamp, notaTexto);
            Console.WriteLine("TODO");

        }

        private void btnListListExams_Click(object sender, RoutedEventArgs e)
        {
            //TODO: var salida = RepoDb.ListExams();
            Console.WriteLine("TODO");
        }

        #endregion Botones llamadas a  CRUDS Exams


        #region opciones de visualización de CRUDS disponibles
        public void OpcionesIniciales()
        {
            Students = RepoDb.ListStudents();
            if (Students == null || Students.Count < 1)
            {
                RepoDb.TenemosAlumno = true;
                btnDeleteStudent.IsEnabled = false;
                btnUpdateStudent.IsEnabled = false;
                btnListStudents.IsEnabled = false;
            }
            else
            {
                PersistenceToStudentComboBox();
            }

            Subjets = RepoDb.ListSubjets();
            if (Subjets == null || Subjets.Count < 1)
            {
                RepoDb.TenemosMateria = true;
                btnDeleteSubject.IsEnabled = false;
                btnUpdateSubject.IsEnabled = false;
                btnListListSubjects.IsEnabled = false;
            }
            else
            {
                PersistenceToSubjectComboBox();
            }

            Exams = RepoDb.ListExamsTodos();
            if (Exams == null || Exams.Count < 1)
            {
                RepoDb.TenemosExams = true;
                btnRegistrarNewExam.IsEnabled = false;
                btnUpdateExam.IsEnabled = false;
                btnDeleteExam.IsEnabled = false;
                btnListListExams.IsEnabled = false;
            }
            else
            {
               //TODO: PersistenceToExam();
            }
        }
        public void MostrarCRUDSStudents()
        {
            btnRegistrarNewStudent.IsEnabled = true;
            btnUpdateStudent.IsEnabled = true;
            btnDeleteStudent.IsEnabled = true;
            btnListStudents.IsEnabled = true;
        }

        public void MostrarCRUDSSubjets()
        {
            btnRegistrarNewSubject.IsEnabled = true;
            btnUpdateSubject.IsEnabled = true;
            btnDeleteSubject.IsEnabled = true;
            btnListListSubjects.IsEnabled = true;
        }

        public void MostrarCRUDSExamenes()
        {
            btnRegistrarNewExam.IsEnabled = true;
            btnUpdateExam.IsEnabled = true;
            btnDeleteExam.IsEnabled = true;
            btnListListExams.IsEnabled = true;
        }

        #endregion opciones de visualización de CRUDS disponibles

    }
}
