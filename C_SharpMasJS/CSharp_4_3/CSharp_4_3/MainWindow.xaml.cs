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

namespace CSharp_4_3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ciudad[] SeisCiudades = new Ciudad[6];
        string preSalida1 = "Salida ordenada alfabéticamente: ";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNewCiudad_Click(object sender, RoutedEventArgs e)
        {
            if (Ciudad.Cuenta < 6)
            {
                AgregarCiudad();
            }
            else
            {
                BtnNewCiudad.IsEnabled = false;
                Console.WriteLine("Ya se guardaron las 6 ciudades");
                OrdemarYMostrar();
            }
          
        }

        private void AgregarCiudad()
        {
            var posAntGuardar = Ciudad.Cuenta;
            SeisCiudades[posAntGuardar] = new Ciudad(txtCiudad.Text);
            Console.WriteLine($"Guardada la ciudad {SeisCiudades[posAntGuardar].Nombre} en" +
                $" la posición {posAntGuardar}");
        }

        private void OrdemarYMostrar()
        {
            string ciudadesOrdenadas = "";
            Array.Sort(SeisCiudades);
            foreach(Ciudad ciudad in SeisCiudades)
            {
                ciudadesOrdenadas += ciudad.Nombre;
            }

            txtBlockOut.Text = $"{preSalida1} {ciudadesOrdenadas}";
        }


    }

}
