using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;




namespace CSharp_4_2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        string StrNombre = "";
        int longitud = 0;
        string StrLetrasNombre = "";
        List<char> CharLetrasNombre = new List<char>();
        string SaltoLinea = "\r\n";



        public MainWindow()
        {
            InitializeComponent();
        }


        
        #region Botones

        private void BtnNombre_Click(object sender, RoutedEventArgs e)
        {
            LimpiarSalida();
            ArrayConNombre();
        }

        private void BtnLista_Click(object sender, RoutedEventArgs e)
        {
            ListaConNombre();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            //TODO: Averiguar que nos está pasando !!!! Socorro 
            //jose DialogResult mDialog = new DialogResult();
            //TODO: ver que necesitamos para , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 porblemas con el using
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButton.YesNo).Equals(DialogResult.Equals("YES")))
            {
                /*
                if(DialogResult.Yes)
                this.Close();*/
            }
        }


        //FASE 1
        private void BtnDictionary_Click(object sender, RoutedEventArgs e)
        {
            Diccionario();
        }
        #endregion Botones

        private void ArrayConNombre()
        {
            CaptarNombre();
            char[] ArrayLetrasNombre = new char[longitud];
            //Opcion 1-Manual
            for (int posicion = 0; posicion < longitud; posicion++)
            {
                ArrayLetrasNombre[posicion] = Char.Parse(StrNombre.Substring(posicion, 1));
            }

            //Opción 2 Directa
            ArrayLetrasNombre = StrNombre.ToCharArray();
          



            foreach (char letra in ArrayLetrasNombre)
            {
                if (!letra.Equals(' '))//No queremos dos espacios seguidos
                    StrLetrasNombre += (letra + " ");
            }
            txtBlockOut.Text = StrLetrasNombre;
            StrLetrasNombre = ""; //La dejamos limpia por si volvemos a pedir

        }
        //FASE 2
        private void ListaConNombre()
        {
            CaptarNombre();

            for (var l = 0; l < longitud; l++) 
            {
                CharLetrasNombre.Add(Char.Parse(StrNombre.Substring(l, 1)));
            }
            //VOCAL CONSONANTE NUMERO  //TODO: sigamos por aquí
           foreach (Char letra in CharLetrasNombre) 
            {
                string tipo = "Tipo no controlado";
                //C# tiene muchos más métodos que java, que nos simplifican el trabajo
                if (Char.IsLetterOrDigit(letra))
                {
                    //Descartamos números. Podriamos usar metodo IsNumber o 
                    //expresiones regulares
                    if (Int16.TryParse(letra.ToString(), out short numero))
                    {
                        tipo = "Número";
                    } //Usamos IndexOf para quedarnos con las Vocales Vowel
                    else if ("aeiouAEIOU".IndexOf(letra) > 0)
                    {
                        tipo = "Vocal";
                    }
                    //Si no es de las de arriba... sólo puede ser una consonante
                    else
                    {
                        tipo = "Consonante";
                    }

                }
                else
                {
                    //El Char es algún signo o espacio no es ni número ni letra
                    tipo = "Signo o espacio";
                }
                 
                StrLetrasNombre += $"{letra} es : {tipo}{SaltoLinea}"; 
            }

            txtBlockOut.Text = StrLetrasNombre;
        }

        //FASE 3
        private void Diccionario()
        {

            CaptarNombre();
            Dictionary<char, int> cantidadChar = new System.Collections.Generic.Dictionary<char, int>();
            do //Si va a la primera MOLA !!!!
            {
                int longInicio = StrNombre.Length;
                string letra =StrNombre.Substring(0,1);
                StrNombre = StrNombre.Replace(letra, "");
                int cantidad = longInicio - StrNombre.Length;
                Char.TryParse(letra, out char letraChar);
                cantidadChar.Add(letraChar,cantidad);
            } while (StrNombre.Length > 0);

            string salida = "" ;
            foreach (KeyValuePair<char,int> par in cantidadChar)
            {
                salida += $"{par.Key}:{par.Value}{SaltoLinea}"; 
            }

            txtBlockOut.Text = salida;
        }

        //FASE 4


        #region Métodos Comunes
        private void LimpiarSalida()
        {
            txtBlockOut.Text = "";
        }

        

        private void CaptarNombre()
        {
            StrNombre = txtBoxNombre.Text;
            longitud = StrNombre.Length;
        }
        #endregion Métodos Comunes

        private void Btn2Listas_Click(object sender, RoutedEventArgs e)
        {
            CaptarNombre();
            List<char> name = new List<char>();
            List<char> surName = new List<char>();
            string salida = "";

            string[] nombreApellido = StrNombre.Split(' ');

            char[] charsNombre =nombreApellido[0].ToCharArray();
            foreach (char letra in charsNombre)
            {
                name.Add(letra);
            }

         
            char[] charsApellido = nombreApellido[1].ToCharArray();
            foreach (char letra in charsApellido)
            {
                surName.Add(letra);
            }
            surName.Add(',');
            surName.Add(' ');

            List<char> fullName = surName.Concat(name).ToList();

            foreach (char letra in fullName)
            {
                salida += letra;
            }
            txtBlockOut.Text = salida;



        }
    }


}
