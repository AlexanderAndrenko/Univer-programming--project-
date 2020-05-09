using Kindergarten.ViewModels.Commands;
using Kindergarten.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kindergarten.ViewModels
{
    public class SingInViewModel : BaseViewModel
    {
        private Page Home;
        public SingInViewModel()
        {
            Home = new Views.Home();
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                     CurrentPage = Home;
                  }));
            }
        }
    }
}
