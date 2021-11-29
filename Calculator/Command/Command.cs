using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Command
{
    public class Command : 
        ICommand
    {
        #region Members

        private Action execute;
        private Func<bool> canExecute;

        #endregion

        #region .Ctor

        public Command(Action executeAction)
            : this(executeAction, null)
        {
            execute = executeAction;
        }

        public Command(Action executeAction, Func<bool> canExecuteAction)
        {
            execute = executeAction;
            canExecute = canExecuteAction;
        }

        #endregion

        #region Event

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }

        #endregion
    }

    public class Command<T> :
        ICommand
    {
        #region Members

        private Action<T> execute;
        private Func<T, bool> canExecute;

        #endregion

        #region .Ctor

        public Command(Action<T> executeAction)
            : this(executeAction, null)
        {
            execute = executeAction;
        }

        public Command(Action<T> executeAction, Func<T, bool> canExecuteAction)
        {
            execute = executeAction;
            canExecute = canExecuteAction;
        }

        #endregion

        #region Event

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion

        #region Methods

        public bool CanExecute(T parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(T parameter)
        {
            execute(parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        #endregion
    }
}
