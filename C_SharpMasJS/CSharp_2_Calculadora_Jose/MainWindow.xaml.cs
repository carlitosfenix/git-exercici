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

namespace PropuestaCalculadora_Solucion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int FirstNumber { get; set; }
        public Operations CurrentOperation { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Buttons Numbers
        private void BtPress7_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "7";
        }

        private void BtPress8_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "8";
        }

        private void BtPress9_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "9";
        }

        private void BtPress4_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "4";
        }

        private void BtPress5_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "5";
        }

        private void BtPress6_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "6";
        }

        private void BtPress1_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "1";
        }

        private void BtPress2_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "2";
        }

        private void BtPress3_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "3";
        }


        private void BtPress0_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text += "0";
        }

        #endregion
        
        #region Operations
        public void Sum()
        {
            if (TryReadCurrentNumber(out int num))
            {
                FirstNumber = num;
                CurrentOperation = Operations.Add;
            }
        }

        public void Sub()
        {
            if (TryReadCurrentNumber(out int num))
            {
                FirstNumber = num;
                CurrentOperation = Operations.Sub;
            }
        }

        public void Multiply()
        {
            if (TryReadCurrentNumber(out int num))
            {
                FirstNumber = num;
                CurrentOperation = Operations.Mult;
            }
        }

        public void Divide()
        {
            if (TryReadCurrentNumber(out int num))
            {
                FirstNumber = num;
                CurrentOperation = Operations.Div;
            }
        }

        private bool TryReadCurrentNumber(out int input)
        {
            if (int.TryParse(TbResult.Text, out int num))
            {
                TbResult.Text = string.Empty;
                input = num;
                return true;
            }
            else
            {
                MessageBox.Show("El formato de número no es correcto");
                input = 0;
                return false;
            };
        }

        #endregion

        #region Button Operations
        private void BtPressAdd_Click(object sender, RoutedEventArgs e)
        {
            Sum();
        }


        private void BtPressSubstract_Click(object sender, RoutedEventArgs e)
        {
            Sub();
        }

        private void BtPressMultiply_Click(object sender, RoutedEventArgs e)
        {
            Multiply();
        }

        private void BtPressDivide_Click(object sender, RoutedEventArgs e)
        {
            Divide();
        }

        #endregion


        private void BtPressCalc_Click(object sender, RoutedEventArgs e)
        {
            if (TryReadCurrentNumber(out int secondNumber))
            {
                switch (CurrentOperation)
                {
                    case Operations.Add:
                        TbResult.Text = (FirstNumber + secondNumber).ToString();
                        break;
                    case Operations.Sub:
                        TbResult.Text = (FirstNumber - secondNumber).ToString();
                        break;
                    case Operations.Mult:
                        TbResult.Text = (FirstNumber * secondNumber).ToString();
                        break;
                    case Operations.Div:
                        TbResult.Text = (FirstNumber / secondNumber).ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        
    }

    public enum Operations
    {
        Add = 0,
        Sub = 1,
        Mult = 2,
        Div = 3
    }
}
