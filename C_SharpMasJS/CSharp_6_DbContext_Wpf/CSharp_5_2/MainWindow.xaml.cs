using Academy_4_DbContext.Lib.Model;
using Academy.Lib.Context;
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

namespace Academy_4_DbContext
//TODO: revisar update en comboBox
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            //Cuando tengamos un alumno y una materia lo pondremos activo
            OpcionesIniciales();

        }

       
        #region Botones llamadas a CRUDS Student
        /**
         * Alta new Alumno, insert into
         */
        private void btnRegistrarNewStudent_Click(object sender, RoutedEventArgs e)
        {
           var cuenta =AddStudentToComboBox(DbContext.RegistrarNewStudent(txtBoxNombre.Text, txtBoxDni.Text));
           if (cuenta >= 0) MostrarCRUDSStudents();
        }
 

        private void btnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            UpdateStudentToComboBox(DbContext.UpdateStudent(txtBoxNombre.Text, txtBoxDni.Text), txtBoxNombre.Text);
        }


        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudentToComboBox(DbContext.DeleteStudent(txtBoxNombre.Text, txtBoxDni.Text));
        }


        private void btnListStudents_Click(object sender, RoutedEventArgs e)
        {
            DbContext.ListStudents();
        }
        #endregion Botones llamadas a  CRUDS Student


        #region Botones llamadas a  CRUDS Subject
        private void btnRegistrarNewSubject_Click(object sender, RoutedEventArgs e)
        {
            var cuenta = AddSubjectToComboBox(DbContext.RegistrarNewSubject(txtBoxMateria.Text, txtBoxTeachear.Text));
            if (cuenta >= 0) MostrarCRUDSSubjets();
        }


        private void btnUpdateSubject_Click(object sender, RoutedEventArgs e)
        {
            UpdateSubjectToComboBox(DbContext.UpdateSubject(txtBoxMateria.Text, txtBoxTeachear.Text), txtBoxMateria.Text);
        }


        private void btnDeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            DeleteSbujectToComboBox(DbContext.DeleteSubject(txtBoxMateria.Text, txtBoxTeachear.Text));
        }


        private void btnListListSubjects_Click(object sender, RoutedEventArgs e)
        {
            DbContext.ListSubjets();
        }
        #endregion CRUDS Subject

        #region Auxiliares ComboBox

        private int AddStudentToComboBox(Student dummyStudent)
        {
            var cuenta = 0;
            if (dummyStudent != null)
            {
                cuenta = comboBoxAlumno.Items.Add(dummyStudent.Name);
                DbContext.TenemosAlumno = true;
                if (DbContext.TenemosMateria) btnRegistrarNewExam.IsEnabled = true;
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
                DbContext.TenemosMateria = true;
                if (DbContext.TenemosAlumno) btnRegistrarNewExam.IsEnabled = true;
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
            if ((comboBoxAlumno.SelectedIndex>=0) && (comboBoxAsignatura.SelectedIndex>=0)
               && !string.IsNullOrWhiteSpace(txtBoxNota.Text) && double.TryParse(txtBoxNota.Text, out var score)
               && (calExam.SelectedDate.Value.Date !=null))
            {

                salida = DbContext.RegistrarNewExam(comboBoxAlumno.SelectedIndex, comboBoxAsignatura.SelectedIndex, calExam.SelectedDate.Value.Date, score );
                if (salida.StartsWith("Examen guardado")) MostrarCRUDSExamenes();

            }
            else
            {
                salida = "Los campos Puntuacion y/o otros no contienen información o no es válida" ;
            }

            Console.WriteLine(salida);
        }

        

        private void btnUpdateExam_Click(object sender, RoutedEventArgs e)
        {
            var indxAlumno = comboBoxAlumno.SelectedIndex;
            var indxMateria = comboBoxAsignatura.SelectedIndex;
            DateTime timeStamp = calExam.SelectedDate.Value.Date;
            var notaTexto = txtBoxNota.Text;

            var salida = DbContext.UpdateExam(indxAlumno, indxMateria, timeStamp, notaTexto);
            Console.WriteLine(salida);
        }

        private void btnDeleteExam_Click(object sender, RoutedEventArgs e)
        {
            var indxAlumno = comboBoxAlumno.SelectedIndex;
            var indxMateria = comboBoxAsignatura.SelectedIndex;
            DateTime timeStamp = calExam.SelectedDate.Value.Date;
            var notaTexto = txtBoxNota.Text;

            var salida = DbContext.DeleteExam(indxAlumno, indxMateria, timeStamp, notaTexto);
            Console.WriteLine(salida);

        }

        private void btnListListExams_Click(object sender, RoutedEventArgs e)
        {
            var salida = DbContext.ListExams();
            Console.WriteLine(salida);
        }

        #endregion Botones llamadas a  CRUDS Exams


        #region opciones de visualización de CRUDS disponibles
        public void OpcionesIniciales()
        {
            btnDeleteStudent.IsEnabled = false;
            btnUpdateStudent.IsEnabled = false;
            btnListStudents.IsEnabled = false;

            btnDeleteSubject.IsEnabled = false;
            btnUpdateSubject.IsEnabled = false;
            btnListListSubjects.IsEnabled = false;

            btnRegistrarNewExam.IsEnabled = false;
            btnUpdateExam.IsEnabled = false;
            btnDeleteExam.IsEnabled = false;
            btnListListExams.IsEnabled = false;
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
