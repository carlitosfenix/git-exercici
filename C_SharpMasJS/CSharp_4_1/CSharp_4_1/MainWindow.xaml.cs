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

namespace CSharp_4_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        string Nombre;
        string Apellido1;
        string Apellido2;
        int Dia; int Mes; int Any;
        string InicioFrase = "Años Bisiestos o Anys de Traspàs: ";
        string StrBisiestos;
        string  NomComple;
        string FechaConta;
        bool IsBisiestoAny =false;
        string AnyBisi = "Any de Traspàs: ";
        string AnyNoBisi = "Año no bisiesto: ";

          


        public MainWindow()
        {
            InitializeComponent();
        }

        private string VerQueAnysSonBisiestos()
        {
            for (var any = 1900; any <= Any; any++)
            {
                if (EsBisiesto(any))
                {
                    StrBisiestos += any + ",";
                    
                }
            }
            return InicioFrase + StrBisiestos;
        }

        /**
         * Un año es bisiesto en el calendario Gregoriano:
         * si es divisible entre 4 y no divisible entre 100, y también si es divisible entre 400.
         * 
         */
        private bool EsBisiesto(int any) {
            var esBisiesto = any % 4;
            if ((esBisiesto == 0 && any % 100>0) || (any % 400 ==0)) 
            {
                return true;
            }
            return false;
        }

        private string ContaNombre() {
            return $"{Apellido1} {Apellido2} , {Nombre}";
        }


        private string  ContaFecha() {

            return $"{Dia} / {Mes} / {Any}";
        }

        private void btnProcesar_Click(object sender, RoutedEventArgs e)
        {

            if (txtBoxNombre.Text.Length > 0 && txtBoxApellido1.Text.Length >0 && txtBoxApellido1.Text.Length > 0
                &&  txtBoxDia.Text.Length > 0 && txtBoxMes.Text.Length > 0 && txtBoxAny.Text.Length > 0)
            {
                Nombre = txtBoxNombre.Text;
                Apellido1 = txtBoxApellido1.Text;
                Apellido2 = txtBoxApellido1.Text;
                int.TryParse(txtBoxDia.Text, out Dia);
                int.TryParse(txtBoxMes.Text, out Mes);
                int.TryParse(txtBoxAny.Text, out Any);


                NomComple = ContaNombre();
                FechaConta = ContaFecha();

                txtOut.Text = " Hola " + NomComple + ". Tu fecha: " + FechaConta;
            }
            else
            {

                MessageBox.Show("Hay que informar todos los campos, revidalos, por favor!!");
                txtOut.Text = "Hay que informar todos los campos, revidalos, por favor!!";
            }

           txtOutBisiesto.Text= VerQueAnysSonBisiestos();

            ElNostreAnyEsDeTraspas();
            SalidaFinal();


        }

        private void SalidaFinal()
        {
            var boolAny = IsBisiestoAny ? AnyBisi : AnyNoBisi;
            txtOutTodo.Text = $"{NomComple} \n {FechaConta} \n + {boolAny}";
        }

        private void ElNostreAnyEsDeTraspas()
        {
            if (EsBisiesto(Any))
            {
                lbAAny.Background = Brushes.Green;
                lbAAny.Content = AnyBisi;
                IsBisiestoAny = true;
            }
            else
            {
                lbAAny.Background = Brushes.Lavender;
                lbAAny.Content = AnyNoBisi;
                IsBisiestoAny = false;

            }
        }
    }
}
