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
        public SingInVM SingIn { get; set; }
        public HomeVM Home { get; set; }
        public DataVM MainData { get; set; }
        public SettingsVM Settings { get; set; }

        public MainWindowVM()
        {
            SingIn = SingInVM.GetInstance();
            Home = HomeVM.GetInstance();
            MainData = DataVM.GetInstance();
            Settings = new SettingsVM();


            Home.dataButton += SetDataPage;
            Home.settingsButton += SetSettingsPage;
            SingIn.singInButton += SetHomePage;
            MainData.backspaceButton += SetPreviousPage;


            CurrentPage = SingIn;
        }

        public void SetDataPage()
        {
            CurrentPage = MainData;
        }
        public void SetSettingsPage()
        {
            CurrentPage = Settings;
        }
        public void SetHomePage()
        {
            CurrentPage = Home;
        }
        public void SetPreviousPage()
        {
            if (CurrentPage == MainData || CurrentPage == Settings)
            {
                CurrentPage = Home;
            }
            else
            {
                /*Тут нужен деструктор объекта класса Account так как мы выходим и надо заходить в систему заново*/
                CurrentPage = SingIn;
            }
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
