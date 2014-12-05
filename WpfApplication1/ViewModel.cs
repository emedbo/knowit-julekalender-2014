using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApplication1.Annotations;
using WpfApplication1.Views;

namespace WpfApplication1
{
    public class MainViewModel : NotifyBase
    {
        private object _content;
        public ICommand Luke3Command { get; set; }

        public object Content
        {
            get { return _content; }
            set
            {
                if (Equals(value, _content)) return;
                _content = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Luke3Command = new LeCommand(() => Content = new Luke3ViewModel());
        }
    }
    public class LeCommand : ICommand
    {
        private readonly Action _action;

        public LeCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }

    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

   
}