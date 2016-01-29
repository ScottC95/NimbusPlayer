using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NimbusPlayer.ViewModel
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        protected EventHandler _internaleCanExecuteChanged;
        
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                return;
            _execute = execute;
            _canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                _internaleCanExecuteChanged += value;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_internaleCanExecuteChanged != null)
                    _internaleCanExecuteChanged -= value;
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (_canExecute != null)
                OnCanExecuteChanged();
        }

        private void OnCanExecuteChanged()
        {
            EventHandler canExecuteChanged = _internaleCanExecuteChanged;
            if (canExecuteChanged != null)
                canExecuteChanged(this, EventArgs.Empty);
        }


    }
}
