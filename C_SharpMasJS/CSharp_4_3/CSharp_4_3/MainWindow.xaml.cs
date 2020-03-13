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
        readonly string PreSalida1y2 = "1-2 Salida ordenada alfabéticamente: ";
        readonly string PreSalida3 = "3 Salida ordenada tras cambiar A por 4: ";
        readonly string PreSalida4 = "4 Salida de chars invertidos: ";


        public MainWindow()
        {
            InitializeComponent();
            btnNewSort.IsEnabled = false;
            btn4Sort.IsEnabled = false;

        }
        #region 1 y 2
        //FASE 1
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
                btnNewSort.IsEnabled = true;
            }
          
        }
       
        private void AgregarCiudad()
        {
            var posAntGuardar = Ciudad.Cuenta;
            SeisCiudades[posAntGuardar] = new Ciudad(txtCiudad.Text);
            Console.WriteLine($"Guardada la ciudad {SeisCiudades[posAntGuardar].Nombre} en" +
                $" la posición {posAntGuardar}");
        }
        
        //FASE 2
        private void OrdemarYMostrar()
        {
            string ciudadesOrdenadas = "";
            Array.Sort(SeisCiudades);
            foreach(Ciudad ciudad in SeisCiudades)
            {
                ciudadesOrdenadas += ciudad.Nombre+", ";
            }

            txtBlockOut.Text = $"{PreSalida1y2} {ciudadesOrdenadas}";
        }
        #endregion 1 y 2
        #region 3
        //FASE 3
        private void BtnNewSort_Click(object sender, RoutedEventArgs e)
        {
            CambiarOrigenPorFinal('a','4');
        }

        
        private void CambiarOrigenPorFinal(char origen, char final) 
        {
            string ciudadesOrdenadas = "";
            foreach (Ciudad ciudad in SeisCiudades)
            {
                ciudad.Nombre = ciudad.Nombre.Replace(origen, final);
                ciudad.Nombre = ciudad.Nombre.Replace(Char.ToUpper(origen), final);
                ciudadesOrdenadas += ciudad.Nombre + ", ";

            }
            Array.Sort(SeisCiudades);
            textBlockOut3.Text = $"{PreSalida3} {ciudadesOrdenadas}";
            btn4Sort.IsEnabled = true;
        }
        #endregion 3
        #region 4
        //FASE 4
        private void Butn4Sort_Click(object sender, RoutedEventArgs e)
        {
            creacionArraysChars();
        }

        private void creacionArraysChars()
        {
            char[] ciudad0 = SeisCiudades[0].Nombre.ToCharArray();
            char[] ciudad1 = SeisCiudades[1].Nombre.ToCharArray();
            char[] ciudad2 = SeisCiudades[2].Nombre.ToCharArray();
            char[] ciudad3 = SeisCiudades[3].Nombre.ToCharArray();
            char[] ciudad4 = SeisCiudades[4].Nombre.ToCharArray();
            char[] ciudad5 = SeisCiudades[5].Nombre.ToCharArray();
            invertirYMostrarChars(ciudad0,ciudad1,ciudad2,ciudad3,ciudad4,ciudad5);
        }

        private void invertirYMostrarChars(char[] ciudad0, char[] ciudad1, char[] ciudad2, char[] ciudad3, char[] ciudad4, char[] ciudad5)
        {
           string salida= PreSalida4;
           Array.Reverse(ciudad0); Array.Reverse(ciudad1); Array.Reverse(ciudad2);
           Array.Reverse(ciudad3); Array.Reverse(ciudad4); Array.Reverse(ciudad5);

           salida += AString (ciudad0);
           salida += AString (ciudad1);
           salida += AString (ciudad2);
           salida += AString (ciudad3);
           salida += AString (ciudad4);
           salida += AString (ciudad5);

           textBlockOut4.Text =salida;
        }

        private string AString(char[] ciudad)
        {
            string salida="";
            for (var posicion=0; posicion<ciudad.Length; posicion++ )
            {
                salida += ciudad[posicion]+ ".";
            }
            return salida + ", ";
        }

      


        #endregion 4
    }

}
