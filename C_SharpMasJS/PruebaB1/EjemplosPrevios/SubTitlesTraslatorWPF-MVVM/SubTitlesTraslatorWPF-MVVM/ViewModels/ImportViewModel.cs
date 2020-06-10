using SubTitlesTraslatorWPF_MVVM.Lib;
using SubTitlesTraslatorWPF_MVVM.Lib.UI;
using SubTitlesTraslatorWPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SubTitlesTraslatorWPF_MVVM.ViewModels
{
    public class ImportViewModel : ViewModelBase
    {
        public Func<List<string>> GetSubtitlesFilesAction { get; set; }
        public Func<string, List<string>> GetFileTextLinesAction { get; set; }
        public Action<List<SubtitleLine>,string> SelectSubtilesForEditAction { get; set; }

        private List<string> _filesNames;
        private string _selectedLanguage;
        private string _selectedFile;

        public List<string> FilesNames
        {
            /*get
            {
                return _filesNames;
            }*/
            //  expresión lambda
            get => _filesNames;

            set
            {
                _filesNames = value;
                //llamamos al metodo sin parámetros
                OnPropertyChange();
            
            }
        }

        public string SelectedFile
        {
            set
            {
              if (_selectedFile != value && value != null)
              {
                    _selectedFile = value;
                    SelectFile(value);
                    OnPropertyChange();
                }
               
            }
            get
            {
               
                return _selectedFile;
            }
        
        }
        

        public IEnumerable<string> LanguageTypes
        {
            get
            {
                return LanguageOptions.Languages.Keys;
            }
        }

        public string SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }
            set
            {
                _selectedLanguage = value;
                OnPropertyChange();
            }
        }
        private void Import()
        {
            if (GetSubtitlesFilesAction != null)
            {
                FilesNames = GetSubtitlesFilesAction().OrderBy(x => x).ToList();  
            }
        }

        public void SelectFile(string fileName)
        {
            if (GetFileTextLinesAction != null)
            {
                var textLines = GetFileTextLinesAction(fileName);

                try
                {
                    string[] extension = fileName.Split(".");
                    var subtitlesLines = SubtitleLine.GetFromTextLines(textLines, extension[extension.Length - 1]);

                    if (SelectSubtilesForEditAction != null)
                    {
                        SelectSubtilesForEditAction(subtitlesLines, SelectedLanguage);
                    }

                } catch (ArgumentException e1)
                {
                    MessageBox.Show(e1.Message);
                }
               
               
            }
         
        }
        public ICommand ImportCommand { get; set; }
        public ImportViewModel()
        {
            //Le pasamos el valor que queremos usar por defecto
            SelectedLanguage = LanguageOptions.Languages.Keys.FirstOrDefault(); //EN 
            ImportCommand = new ModelCommand(x =>Import());
        }

        
        
    }
}
