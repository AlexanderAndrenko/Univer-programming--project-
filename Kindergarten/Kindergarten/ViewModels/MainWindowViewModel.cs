using Kindergarten.ViewModels.Commands;
using Kindergarten.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kindergarten.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public Page GetHome()
        {
            return Home;
        }        

        public MainWindowViewModel()
        {
            SingIn = new Views.SingIn();
            Home = new Views.Home();

            CurrentPage = SingIn;
        }

        
    }
}
