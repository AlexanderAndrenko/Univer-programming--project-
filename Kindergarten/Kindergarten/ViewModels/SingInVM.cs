using Kindergarten.Models;
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
using System.Windows.Media;
using System.Xml;

namespace Kindergarten.ViewModels
{
    public class SingInVM : BaseVM
    {
        #region Constructor
        private static SingInVM instance;//Единственный объект класса в соответствии с паттерном Singleton

        /*метод создающий единственный объект класса, если он ещё не создан или возвращает существующий*/
        public static SingInVM GetInstance()
        {
            if (instance == null)
                instance = new SingInVM();
            return instance;
        }
        private SingInVM()
        {
            OpenHomePage = new SingInCommand(singIn_btn_click);
            singInButton = () => { };
            ColorOfMainStackPanel = Brushes.White;

            #region Need to delete in release, just for debug
            Login = "admin";
            Password = "admin";
            #endregion //Need to delete in release, just for debug
        }
        #endregion //Constructor

        public delegate void SingInProcess();
        public event SingInProcess singInButton;
        public SingInCommand OpenHomePage { get; private set; }
        public SingInCommand OpenServerSettigns { get; private set; }
        public string Login { get; set; }
        public string Password { private get; set; }

        private SolidColorBrush _colorOfMainStackPanel;
        public SolidColorBrush ColorOfMainStackPanel 
        { 
            get => _colorOfMainStackPanel;
            set
            {
                _colorOfMainStackPanel = value;
                RaisePropertyChanged();
            }
        }

        private void singIn_btn_click()
        {
            if (Login != "" && Password != "" && SingInModel.CheckLogin(Login, Password))
            {
                singInButton();
                Password = "";//Стираем из памяти пароль
            }
            else
            {

                ColorOfMainStackPanel = Brushes.Red;
            }
        }



    }
}
