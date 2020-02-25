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

/**
 * Carlos Acevedo 24/02/2020
 */

namespace WPF2_Calculadora_Vitaminas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

	
		string operacion; //OK
		bool pendiente =false;
		 string valDisplay;
		//float(32bits) , double(64bits) y decimal (128bits) 
		decimal numeroA = 0;  
		decimal numeroB = 0;
		decimal memoria = 0;
		

		public MainWindow()
        {
            InitializeComponent();
			
		
        }

		


		public  void BtMemoriaF_Click(object sender, RoutedEventArgs e)
		{
			string valorSender= (sender as Button).Name.ToString();
			Decimal.TryParse(TbResult.Text, out decimal decimalDisplay);

			switch (valorSender)
			{
				case "BtPressMin": //restamos a la memoria
					memoria -= decimalDisplay;
					break;
				case "BtPressMPlus": //sumamos a la memoria
					memoria += decimalDisplay;
					break;
				case "BtPressMRead": //Leer meroria
					TbResult.Text = ""+memoria;
					break;
				case "BtPressMClear": //Reset memoria
					memoria = 0;
					break;
			}
			//El verde indica que tenemos algo en memoria
			if (memoria > 0)
			{
				BtPressMRead.Background = Brushes.Green; 
			}
			else
			{
				BtPressMRead.Background = Brushes.Gray;
			}

			//FET: cambio de color en la UI
			//FET: enviar valor de display a la UI
		}

		

		public void BtPressLimpiar_Click(object sender, RoutedEventArgs e)
		{
			TbResult.Text = "0";

		}

		public  void BtPressComa_Click(object sender, RoutedEventArgs e)
		{
			//TODO: revisar negado o iverso como va en JS el ! de Java
			if (TbResult.Text.Contains("."))
			{

			}
			else
			{
				TbResult.Text += ".";
			}
		}

		public  void BtPressN_Click(object sender, RoutedEventArgs e)
		{
			string n = (sender as Button).Content.ToString();

			if (pendiente == true)
			{
				TbResult.Text = "0";
				pendiente = false;
			}
			else
			{

			}
			valDisplay = TbResult.Text;
			if (valDisplay == "0")
			{
				valDisplay = n;
			}
			else
			{
				valDisplay += n;
			}
			TbResult.Text = valDisplay;
		}

		public void BtOpeacion_Click(object sender, RoutedEventArgs e)
		{
			string operacionClicada = (sender as Button).Content.ToString();
			Decimal.TryParse(TbResult.Text, out decimal textBoxDecimal);
			switch (operacionClicada)
			{
				case "+":
					numeroA = textBoxDecimal;
					operacion = "+";
					break;
				case "-":
					numeroA = textBoxDecimal;
					operacion = "-";
					break;
				case "*":
					numeroA = textBoxDecimal;
					operacion = "*";
					break;
				case "/":
					numeroA = textBoxDecimal;
					operacion = "/";
					break;
			}
			pendiente = true;

		}

		public void BtPressCalc_Click(object sender, RoutedEventArgs e)
		{
	
			Decimal.TryParse(TbResult.Text, out decimal textBoxDecimal);
			switch (operacion)
			{
				case "+":
					numeroB = numeroA + textBoxDecimal;
					break;
				case "-":
					numeroB = numeroA - textBoxDecimal;
					break;
				case "*":
					numeroB = numeroA * textBoxDecimal;
					break;
				case "/":
					numeroB = numeroA / textBoxDecimal;
					break;
			}

			TbResult.Text = ""+numeroB;
		}


		public  void BtSignChnage_Click(object sender, RoutedEventArgs e)
		{
			if (TbResult.Text.Contains("-"))
			{
				int longitud = TbResult.Text.Length;
				TbResult.Text = TbResult.Text.Substring(1, longitud-1);
				
			}
			else
			{
				TbResult.Text = "-" + TbResult.Text;
			}
		}


	}
}
