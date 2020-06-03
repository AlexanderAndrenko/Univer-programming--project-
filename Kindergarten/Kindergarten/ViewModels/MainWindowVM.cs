using Kindergarten.ViewModels.Commands;
using Kindergarten.ViewModels.DataViewModels;
using Kindergarten.ViewModels.SettingsViewModels;
using Kindergarten.Views;
using Kindergarten.Views.Data;
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
        public HomeVM Home { get; set; }
        public DataVM MainData { get; set; }
        public SettingsVM Settings { get; set; }

        public MainWindowVM()
        {
            Home = HomeVM.GetInstance();
            MainData = new DataVM();
            Settings = new SettingsVM();


            Home.dataButton += SetDataPage;
            Home.settingsButton += SetSettingsPage;

            CurrentPage = Home;
        }

        public void SetDataPage()
        {
            CurrentPage = MainData;
        }

        public void SetSettingsPage()
        {
            CurrentPage = Settings;
        }

        private object _currentPage;
        public object CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                RaisePropertyChanged();
            }
        }
    }
}
