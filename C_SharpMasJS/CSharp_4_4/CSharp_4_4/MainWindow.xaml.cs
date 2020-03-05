using System;
using System.Collections.Generic;
using System.Globalization;
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
        float Cents1    =   0.01f;
        float Cents5    =   0.05f;
        float Cents10   =   0.1f;
        float Cents50   =   0.5f;
        float Moneda1   =   1;
        float Moneda2   =   2;
        float Billete5  =   5;
        float Billete10 =  10;
        float Billete20 =  20;
        float Billete50 =  50;
        float Billete100 =100;
        float Billete200 =200;
        float Billete500 =500;

        float PrecioComida = 0;

        string[] PlatosMenu;
        float[] PlatosPrecio = new float[5];
        string TextoPlatos = "Ensalada Catalana,Paella,Sopa,Chuletón,Bacalao al Pil Pil";
        string TextoPrecios = "3.5, 9.8, 3.6, 16.6, 12.4";

        List<LineaPedido> ListaPedido = new List<LineaPedido>();
        Dictionary<string, float> Monedas = new Dictionary<string, float>();

        string TextoPagoSugerido = "tendrías que pagar con: "; 

     

        public MainWindow()
        {
            InitializeComponent();
            LlenarArraysMenuPrecio();
            LlenarDictionayMoneda();
            btnFinPedido.IsEnabled = false;
    }

        private void LlenarDictionayMoneda()
        {
            Monedas.Add("Billete 500",Billete500);
            Monedas.Add("Billete 200", Billete200);
            Monedas.Add("Billete 100", Billete100);
            Monedas.Add("Billete 50", Billete50);
            Monedas.Add("Billete 20", Billete20);
            Monedas.Add("Billete 10", Billete10);
            Monedas.Add("Billete 5", Billete5);
            Monedas.Add("Moneda 2", Moneda2);
            Monedas.Add("Moneda 1", Moneda1);
            Monedas.Add("Moneda 50cts", Cents50);
            Monedas.Add("Moneda 10cts", Cents10);
            Monedas.Add("Moneda 5cts", Cents5);
            Monedas.Add("Moneda 1cts", Cents1);


        }

        private void LlenarArraysMenuPrecio() 
        {
            PlatosMenu = TextoPlatos.Split(',');
            string[]  strPrecios = TextoPrecios.Split(',');
            int count = 0;
            foreach (string precio in strPrecios)
            {
                float perc = 3.5f;
                float.TryParse(precio, NumberStyles.Float, CultureInfo.InvariantCulture, out PlatosPrecio[count]);
                Console.WriteLine(perc);
                count++;
            }

            MostrarEnPantalla();
        }

        private void MostrarEnPantalla()
        {
            var salidaPrecios="";
            foreach (string plato in PlatosMenu)
            {
                txtBlockPlatos.Text +=$"{plato}, ";
            }

            foreach (float precio in PlatosPrecio)
            {
                salidaPrecios += $"{precio}, " ;
            }

            txtBlockPrecios.Text += salidaPrecios;
        }

        private void BtnPedir_Click(object sender, RoutedEventArgs e)
        {
            AgregarPlatoAlPedido();
          
        }

        private void AgregarPlatoAlPedido()
        {
            var platoEntradaUser = txtBoxItemPedido.Text;
            bool correcto = false;
            int posicion =0;
            int posicionPlato = 0;

            foreach(string platoMEnu in PlatosMenu)
            {
                if (platoMEnu.Contains(platoEntradaUser) )//&& platoMEnu.Equals(platoEntradaUser)
                {
                    correcto = true;
                    posicionPlato = posicion;
                    //Si hay plato correcto podemos hacer pedido
                    btnFinPedido.IsEnabled = true;
                }
                posicion++;
            }

            if (correcto)
            {
               ListaPedido.Add(new LineaPedido(platoEntradaUser, PlatosPrecio[posicionPlato]));
                Console.WriteLine(ListaPedido[LineaPedido.Count-1].ToString());
            }
            else
            {
                //TODO: José socorro!!    MessageBoxButtons.YesNo, MessageBoxIcon.Question no me va
                Console.WriteLine($"El plato{platoEntradaUser}, no está hoy el el menú, pide otro por favor");
                 string message =
        $"Lo siento, {platoEntradaUser}, no está en el menú, ¿le apetece otro plato?";
                const string caption = "Aceptar";
                 MessageBox.Show(message, caption);
            }
        }

        private void BtnFinPedido_Click(object sender, RoutedEventArgs e)
        {
            //Indicamos que no queremos más platos y enviamos a cocina
            btnPedir.IsEnabled = false;
            CalcularUsoBilletesMonedas();

        }

        private void CalcularUsoBilletesMonedas()
        {
            var importeCuenta = LineaPedido.Total + LineaPedido.Total * 0.21;
            var digits = 2;
            double mult = Math.Pow(10.0, digits);
            double redondeo = Math.Truncate( mult * importeCuenta) / mult;
            importeCuenta = redondeo;
            var pendiente = importeCuenta;

            do
            {
                
                foreach (var mKeyValue in Monedas)
                {   //While pendiente  es igual o > de 500 en caso contrario 200, 100, 50 ....
                    while (pendiente >= mKeyValue.Value)
                    {
                        pendiente -= mKeyValue.Value;
                        TextoPagoSugerido += $" {mKeyValue.Key}, ";
                    }
                }
            } while (pendiente > 0.01);

            Console.WriteLine(TextoPagoSugerido);
            txtPagoSugerido.Text = $" La cuenta con IVA es de: {importeCuenta} {TextoPagoSugerido}";
        }
    }


    public class LineaPedido
    {
        private string _plato;
        private float _precio;
        private int _id;
        private static int _count;
        private static float _total;

        public string Plato { get => _plato; set => _plato = value; }
        public float Precio { get => _precio; set => _precio = value; }
        public int Id { get => _id; set => _id = value; }
        public static int Count { get => _count; set => _count = value; }
        public static float Total { get => _total; set => _total = value; }

        public LineaPedido(string plato, float precio)
        {
            Plato = plato;
            Precio = precio;
            Id = Count;
            Total += precio;
            Count++;
        }

        override
            public string ToString()
        {
            return $"El plato de {Plato} cuesta {Precio}, el id de pedido lineaPedido es: {Id} . La cuenta suma: {Total}";
        }


    }
}
