using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kindergarten.ViewModels;
using Kindergarten.Views;
using Kindergarten.ViewModels.Commands;
using System.Runtime.InteropServices;
using static Kindergarten.ViewModels.SingInVM;
using static Kindergarten.ViewModels.BaseVM;

namespace Kindergarten.ViewModels.Commands
{
    public class SingInCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;
        public SingInCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}


