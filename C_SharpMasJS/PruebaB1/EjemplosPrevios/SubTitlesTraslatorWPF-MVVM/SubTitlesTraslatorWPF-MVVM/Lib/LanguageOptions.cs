using System;
using System.Collections.Generic;
using System.Text;

namespace SubTitlesTraslatorWPF_MVVM.Lib
{
    public static class LanguageOptions
    {
        private static Dictionary<string, string> _languages;

        public static Dictionary<string, string> Languages
        {
            get
            {
                if (_languages == null)
                {
                    _languages = new Dictionary<string, string>();
                    _languages.Add("EN", "en");
                    _languages.Add("ESP", "esp");
                }
                return _languages;
            }
        
        }


    }
}
