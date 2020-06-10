using System;
using System.Windows.Input;

namespace SubTitlesTraslatorWPF_MVVM.Lib.UI
{
    public class ModelCommand : ICommand
    {

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute.Invoke(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #endregion ICommand Members

        #region Constructors

        public ModelCommand(Action<object> execute)
            : this(execute, null) { }

        public ModelCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion Constructors


        private readonly Action<object> _execute = null;
        private readonly Predicate<object> _canExecute = null;
    }
}
