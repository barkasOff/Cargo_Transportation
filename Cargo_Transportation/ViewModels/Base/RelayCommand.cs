using System;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.Base
{
    public class                    RelayCommand : ICommand
    {
        private readonly Action     _action;

        public event EventHandler   CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action) => _action = action;

        public bool                 CanExecute(object parameter) => true;

        public void                 Execute(object parameter) => _action();
    }
    public class                        RelayCommandParameter : ICommand
    {
        private readonly Action<object> _action;

        public event EventHandler       CanExecuteChanged = (sender, e) => { };

        public RelayCommandParameter(Action<object> action) => _action = action;

        public bool                     CanExecute(object parameter) => true;
        public void                     Execute(object parameter) => _action(parameter);
    }
}
