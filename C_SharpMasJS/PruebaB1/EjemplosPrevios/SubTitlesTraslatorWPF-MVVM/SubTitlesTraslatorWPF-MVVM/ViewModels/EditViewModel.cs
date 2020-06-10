using SubTitlesTraslatorWPF_MVVM.Lib.UI;
using SubTitlesTraslatorWPF_MVVM.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SubTitlesTraslatorWPF_MVVM.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        private Dictionary<string, List<SubtitleLine>> LinesByLanguage { get; set; }
        private List<SubtitleLine> _lines = new List<SubtitleLine>();
       

        public List<SubtitleLine> Lines
        {
            get
            {
                return _lines;
            }
            set
            {
               _lines = value;
               OnPropertyChange();
            }

         }

        public void  SelectImportLines(List<SubtitleLine> lines, string importLanguage)
        {
            if (!LinesByLanguage.ContainsKey(importLanguage))
            {
                LinesByLanguage.Add(importLanguage, new List<SubtitleLine>(lines));
                Lines = lines;
            }
        }

        public EditViewModel()
        {
            ExportCommand = new ModelCommand(x=> Export());
            LinesByLanguage = new Dictionary<string, List<SubtitleLine>>();
        }
        #region Testeo 
        //Icommand ExportCommand es la interface que conecta con la Vista mediante el Binding
        public ICommand ExportCommand { get; set; }
        public void Export()
        {
            var item = Lines.FirstOrDefault();
            MessageBox.Show($"{item.Text}");
        }
        #endregion Testeo
    }
}
