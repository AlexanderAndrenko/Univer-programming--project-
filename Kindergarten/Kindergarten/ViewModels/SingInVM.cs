using Kindergarten.ViewModels.Commands;
using Kindergarten.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kindergarten.ViewModels
{
    public class SingInVM : BaseVM
    {
        public SingInCommand OpenHomePage { get; private set; }

        public SingInVM()
        {
        }
    }
}
