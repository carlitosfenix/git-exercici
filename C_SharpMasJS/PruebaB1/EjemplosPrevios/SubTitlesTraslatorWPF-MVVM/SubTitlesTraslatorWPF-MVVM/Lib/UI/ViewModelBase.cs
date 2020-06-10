using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SubTitlesTraslatorWPF_MVVM.Lib.UI
{
    public class ViewModelBase : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange([CallerMemberName] string propertyName = null)
        //CallerMemberName quiere decir que el string no se ha de indicar ya que va implícito
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
}
