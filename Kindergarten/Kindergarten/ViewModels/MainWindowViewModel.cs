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
        //private Page SingIn;
        //private Page Home;
        private Page Data;
        private Page Setting;

        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public Page SingIn { get => SingIn; set => SingIn = value; }
        public Page Home { get => Home; set => Home = value; }

        public MainWindowViewModel()
        {
            SingIn = new Views.SingIn();
            Home = new Views.Home();

            CurrentPage = SingIn;
        }

        
    }
}
