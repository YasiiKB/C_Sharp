using System;
using System.Windows.Input;

namespace WpfApp2_RelayCommand
{
    public class RelayCommand : ICommand
    {
        // fields to store the execute and canExecute delegates
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        // constructor to initialize the fields
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); // throw an exception if the execute delegate is null
            _canExecute = canExecute; // assigns the canExecute delegate to the _canExecute field. 
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter); // returns true if the canExecute delegate is null or the result of the canExecute delegate is true 
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}