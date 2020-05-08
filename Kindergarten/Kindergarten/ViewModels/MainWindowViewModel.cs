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
        private BaseViewModel _selectedViewModel = new SingInViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set 
            { 
                _selectedViewModel = value;                
            }           
        }

        public void SetPage(MainWindowViewModel page)
        {
            _selectedViewModel = page;
        }


    }
}
