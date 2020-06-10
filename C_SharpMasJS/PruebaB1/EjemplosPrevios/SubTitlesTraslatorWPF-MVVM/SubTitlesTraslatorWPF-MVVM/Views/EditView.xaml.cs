using SubTitlesTraslatorWPF_MVVM.ViewModels;
using SubTitlesTraslatorWPF_MVVM.Models;
using System.Windows.Controls;


namespace SubTitlesTraslatorWPF_MVVM.Views
{
    /// <summary>
    /// Lógica de interacción para EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        public EditViewModel ViewModel { get; set; }
        public EditView()
        {
            InitializeComponent();
            //TODO: En el video 4 en 13:46 no aparece la instanciación ni la asignación al DataContext
           ViewModel = new EditViewModel();
           DataContext = ViewModel;
        }

        


    }
}
