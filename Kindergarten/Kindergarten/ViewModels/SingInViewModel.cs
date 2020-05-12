using Kindergarten.ViewModels.Commands;
using Kindergarten.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kindergarten.ViewModels
{
    public class SingInViewModel : MainWindowViewModel
    {
        public SingInViewModel()
        {
            AddCommand = new SingInCommand(DisplayHomePage);
        }
 
        public SingInCommand AddCommand { get; private set; }

        public void DisplayHomePage()
        {
            CurrentPage = GetHome();
        }

    }
}
