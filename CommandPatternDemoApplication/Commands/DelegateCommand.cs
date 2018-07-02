using System;
using System.Windows.Input;

namespace CommandPatternDemoApplication.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action action, Func<bool> canExecute = null)
        {
           _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute.Invoke();
            }

            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke();
        }
    }
}