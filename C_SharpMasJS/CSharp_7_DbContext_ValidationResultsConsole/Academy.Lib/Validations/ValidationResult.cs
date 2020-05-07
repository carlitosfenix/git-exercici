using System.Collections.Generic;

namespace Academy_4_DbContext.Lib.Validations
{
    public class ValidationResult
    {
        private bool _isSuccess;
        public static string NewLine => "\r\n";
        public bool IsSuccess { get => _isSuccess; set => _isSuccess = value; }
        public List<string> Errors { get ; set; } = new List<string>();

        public string AllErrors
        {
            get
            {
                var output = string.Empty;

                foreach (var error in Errors)
                    output += error + NewLine;

                return output;
            }
        }
    }

    public class ValidationResult<T> : ValidationResult
    {
        public T ValidatedResult { get; set; }
    }
}
