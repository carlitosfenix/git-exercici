using SubTitlesTraslatorWPF_MVVM.Models;

using System.Collections.ObjectModel;

using System.Windows;


namespace SubTitlesTraslatorWPF_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ImportView.ViewModel.SelectSubtilesForEditAction = (lines, language) =>
            {
                EditView.ViewModel.SelectImportLines(lines,language);//No necesitamos el ObservableCollection new ObservableCollection<SubtitleLine>(lines);
            };
        }

        /// <summary>
        /// Podemos crear métodos que se ejecuten al cargar la view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportView_Loaded(object sender, RoutedEventArgs e)
        {
           //  < uc:ImportView x:Name = "ImportView" Grid.Column = "0" Margin = "5"
           // Loaded = "ImportView_Loaded" ></ uc:ImportView >
        }
    }
}
