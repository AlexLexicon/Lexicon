using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Lexicon.WPF.MVVM
{
    public class Command : ICommand
    {
        protected Action executeWithoutParams;
        protected Action<object> executeWithParams;
        protected Predicate<object> canExecute;
        public Command(Action executeWithoutParams) : this(executeWithoutParams, null) { }
        public Command(Action executeWithoutParams, Predicate<object> canExecute) => Create(executeWithoutParams, null, canExecute);
        public Command(Action<object> executeWithParams) : this(executeWithParams, null) { }
        public Command(Action<object> executeWithParams, Predicate<object> canExecute) => Create(null, executeWithParams, canExecute);
        private void Create(Action executeWithoutParams, Action<object> executeWithParams, Predicate<object> canExecute)
        {
            this.executeWithoutParams = executeWithoutParams;
            this.executeWithParams = executeWithParams;
            this.canExecute = canExecute;
        }
        public void Execute(object parameters)
        {
            if (executeWithoutParams is not null)
                executeWithoutParams();
            else if (executeWithParams is not null)
                executeWithParams(parameters);
        }
        [DebuggerStepThrough]
        public bool CanExecute(object parameters) => canExecute == null || canExecute(parameters);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
