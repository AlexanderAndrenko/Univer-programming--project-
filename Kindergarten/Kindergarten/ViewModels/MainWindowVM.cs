using Kindergarten.ViewModels.Commands;
using Kindergarten.ViewModels.DataViewModels;
using Kindergarten.ViewModels.DataViewModels.PagesViewModel;
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
        public Account CurrentAccount { get; set; }

        public MainWindowVM()
        {
            SingIn = SingInVM.GetInstance();  
           
            SingIn.singInButton += SetHomePage;
            SingIn.singInButton += SetAccountParameters;

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


            Home = HomeVM.GetInstance();
            MainData = DataVM.GetInstance();
            Settings = SettingsVM.GetInstance();
            CredentialForServerVM.GetInstance();
            ChildrenAddVM.GetInstance();

            MainData.backspaceButton += SetPreviousPage;
            Settings.backspaceButton += SetPreviousPage;
            Home.dataButton += SetDataPage;
            Home.settingsButton += SetSettingsPage;
            Home.singOut += SetPreviousPage;

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
                CurrentAccount.DeleteObject();//удаление объекта класса Account так как мы выходим из учетной записи
                CurrentPage = SingIn;//установка стартовой страницы
            }
        }

        public void SetAccountParameters()
        {
            CurrentAccount = Account.GetInstance(SingIn.Login);
            MainData.UserNameSurname = CurrentAccount.Name + " " + CurrentAccount.Surname;
            Settings.UserNameSurname = CurrentAccount.Name + " " + CurrentAccount.Surname;
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
