using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Views;

namespace Kindergarten.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeCommands DataButton { get; private set; }
        public HomeCommands SettingsButton { get; private set; }

        public HomeViewModel()
        {
        }
        public void Stub()
        {

        }

    }
}
