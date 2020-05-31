using Kindergarten.ViewModels.Commands;
using Kindergarten.ViewModels.DataViewModels;
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
    public class MainWindowVM : BaseVM
    {
        public BaseVM Home { get; set; }
        public MainWindowVM()
        {
            Home = new HomeVM();

            CurrentPage = Home;
        }
    }
}
