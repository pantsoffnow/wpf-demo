using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using CommandPatternDemoApplication.Commands;

namespace CommandPatternDemoApplication.ViewModels
{
    public class NameViewModel : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;

                OnPropertyChanged();
                ((DelegateCommand)SubmitCommand).CanExecute(null);
            }
        }

        public ICommand SubmitCommand { get; private set; }

        public NameViewModel()
        {
            SubmitCommand = new DelegateCommand(ProcessSubmitCommand, ProcessSubmitCanExecute);
        }

        private bool ProcessSubmitCanExecute()
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void ProcessSubmitCommand()
        {
            //Persist Data
            Console.WriteLine(@"Processing Submit Command.");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}