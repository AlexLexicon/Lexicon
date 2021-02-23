using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Lexicon.WPF.MVVM
{
    public class Command : ICommand
    {
        protected readonly Action<object> execute;
        protected readonly Predicate<object> canExecute;
        public Command(Action<object> execute) : this(execute, null) { }
        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute cannot be null");
            this.canExecute = canExecute;
        }
        public void Execute(object parameters) => execute(parameters);
        [DebuggerStepThrough]
        public bool CanExecute(object parameters) => canExecute == null || canExecute(parameters);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
