using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Views;
using Kindergarten.ViewModels.DataViewModels;

namespace Kindergarten.ViewModels
{
    public class HomeVM : BaseVM
    {
        public HomeCommands DataButton { get; private set; }
        public HomeCommands SettingsButton { get; private set; }

        public HomeVM()
        {
            DataButton = new HomeCommands(SetDataPage);
        }
        public void SetDataPage()
        {
            CurrentPage = new DataVM();
        }

    }
}
