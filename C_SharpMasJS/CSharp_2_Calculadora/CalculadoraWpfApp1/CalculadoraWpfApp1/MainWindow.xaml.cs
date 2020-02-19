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

namespace CalculadoraWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double siNoNumA = 0.0; double siNoNumB = 0.0;
        
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOClick(object sender, RoutedEventArgs e)
        {
            var operacion = (sender as Button).Content;

            ObtenerNumeros();

            switch (operacion)
            {
                case "+":
                    Suma();
                    break;
                case "-":
                    Resta();
                    break;
                case "*":
                    Producto();
                    break;
                case "/":
                    Division();
                    break;
            }
           
              
        }

        private bool ObtenerNumeros()
        {
            var numeroA = Double.TryParse(numA.Text, out siNoNumA);
            var numeroB = Double.TryParse(numB.Text, out siNoNumB);
            return (numeroA && numeroB);
        }

        private void Suma() 
        {
            var suma = siNoNumA+ siNoNumB;
            MessageBox.Show($"El resultado es: {suma}");
            Console.WriteLine($"El resultado es: {suma}");
            numResultado.Text =""+suma;
        }

        private void Resta()
        {
            var resta = siNoNumA - siNoNumB;
            MessageBox.Show($"El resultado es: {resta}");
            Console.WriteLine($"El resultado es: {resta}");
            numResultado.Text = "" + resta;
        }

        private void Producto()
        {
            var producto = siNoNumA * siNoNumB;
            MessageBox.Show($"El resultado es: {producto}");
            Console.WriteLine($"El resultado es: {producto}");
            numResultado.Text = "" + producto;
        }

        private void Division()
        {
            var division = siNoNumA / siNoNumB;
            MessageBox.Show($"El resultado es: {division}");
            Console.WriteLine($"El resultado es: {division}");
            numResultado.Text = "" + division;
        }
    }
}
