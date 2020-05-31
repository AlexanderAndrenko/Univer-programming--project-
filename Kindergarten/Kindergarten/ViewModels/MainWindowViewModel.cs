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
        public BaseViewModel Home { get; set; }
        public MainWindowViewModel()
        {
            Home = new HomeViewModel();

            CurrentPage = Home;
        }

        private BaseViewModel _currentPage;
        public BaseViewModel CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value)
                    return;
                _currentPage = value;
                RaisePropertyChanged();
            }
        }


    }
}
