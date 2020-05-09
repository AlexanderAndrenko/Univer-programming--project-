using Kindergarten.ViewModels.Commands;
using Kindergarten.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kindergarten.ViewModels
{
    public class SingInViewModel : MainWindowViewModel
    {
        public ICommand SingInExecute
        {
            get
            {
                return new SingInCommand((obj) =>
                {
                    CurrentPage = Home;
                });
            }
        }
    }
}
