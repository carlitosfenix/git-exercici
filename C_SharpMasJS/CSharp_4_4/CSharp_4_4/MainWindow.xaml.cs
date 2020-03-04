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

namespace CSharp_4_4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Moneda1   =   1;
        int Moneda2   =   2;
        int Billete5  =   5;
        int Billete10 =  10;
        int Billete20 =  20;
        int Billete50 =  50;
        int Billete100 =100;
        int Billete200 =200;
        int Billete500 =500;

        float PrecioComida = 0;
        string[] PlatosMenu = new string[5];
        float[] PrecioPlato = new float[5];
        string TextoPlatos = "Ensalada Catalana, Paella, Sopa, Chuletón, Bacalao al Pil Pil";
        string TextoPrecios = "3.5, 9.8, 3.6, 16.6, 12.4";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void llenarArraysMenuPrecio() 
        {
            //TODO: no megusta así ver otra forma
            for (var posicion = 0 ; posicion < PlatosMenu.Length; posicion++)
            {
                PlatosMenu[posicion] = "";
                PrecioPlato[posicion] =
            }
        }
    }
}
