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
       
        double NotaAlumno;
        string KeyWordOut = "runyoufools";

        public MainWindow()
        {
            InitializeComponent();

        }

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

      
    }
}
