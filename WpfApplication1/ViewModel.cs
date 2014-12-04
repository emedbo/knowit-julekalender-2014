using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using Julekalender.Luker;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    public class ViewModel : NotifyBase
    {
        public List<List<SuperBool>> LeList { get; set; }
        private Luke3 _luke3;
        private SuperBool _current;
        private int _count;
        public ICommand NextCommand { get; set; }
        public ICommand AutoCommandToggle { get; set; }
        public DispatcherTimer Timer { get; set; }

        public int Count
        {
            get { return _count; }
            set
            {
                if (value == _count) return;
                _count = value;
                OnPropertyChanged();
            }
        }

        public SuperBool Current
        {
            get { return _current; }
            set
            {
                if (Equals(value, _current)) return;
                _current = value;
                OnPropertyChanged();
            }
        }

        public ViewModel()
        {
            LeList = new List<List<SuperBool>>();
            NextCommand = new LeCommand(Next);
            AutoCommandToggle = new LeCommand(ToggleAuto);
            _luke3 = new Luke3();
            _luke3.Init();
            for (int i = 0; i < 10; i++)
            {
                var list = new List<SuperBool>();
                for (int j = 0; j < 10; j++)
                {
                    list.Add(new SuperBool { Number = i * 10 + j });
                }
                LeList.Add(list);
            }
            Current = Get(0);
            Current.IsCurrent = true;
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(0.1);
            Timer.Tick +=Tick;
            Timer.IsEnabled = false;
        }

        private void Tick(object sender, EventArgs e)
        {
            Next();
        }

        private void ToggleAuto()
        {
            if (Timer.IsEnabled)
            {
                Timer.Stop();
            }
            else
            {
                Timer.Start();
            }
        }

        private void Next()
        {
            if (Count >= 200)
            {
                Timer.Stop();
                return;
            }
            var poss = _luke3.PossibleMoves(Current.Number).OrderBy(x => x).ToArray();
            var next = _luke3.MoveTo(Current.Number, _luke3.Board, poss);
            _luke3.Board[Current.Number] = !_luke3.Board[Current.Number];
            Current.IsCurrent = false;
            Current.Value = _luke3.Board[Current.Number];
            Current = Get(next);
            Current.IsCurrent = true;
            Count++;
        }

        private SuperBool Get(int num)
        {
            return LeList.SelectMany(x => x).Single(x => x.Number == num);
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

    public class SuperBool : NotifyBase
    {
        private bool _value;
        private bool _isCurrent;

        public bool Value
        {
            get { return _value; }
            set
            {
                if (value.Equals(_value)) return;
                _value = value;
                OnPropertyChanged();
            }
        }

        public int Number { get; set; }

        public bool IsCurrent

        {
            get { return _isCurrent; }
            set
            {
                if (value.Equals(_isCurrent)) return;
                _isCurrent = value;
                OnPropertyChanged();
            }
        }
    }
}