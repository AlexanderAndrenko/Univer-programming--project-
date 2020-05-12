using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kindergarten.ViewModels;
using Kindergarten.Views;
using Kindergarten.ViewModels.Commands;

namespace Kindergarten.ViewModels.Commands
{
    public class SingInCommand : ICommand
    {
        private Action execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SingInCommand(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute.Invoke();
        }
    }
}


