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
        }
        #endregion //Constructor

        public delegate void SingInProcess();
        public event SingInProcess singInButton;
        public SingInCommand OpenHomePage { get; private set; }
        public string Login { get; set; }
        public string Password { private get; set; }

        private void singIn_btn_click()
        {
            if (SingInModel.CheckLogin(Login, Password))
            {
                singInButton();
            }            
        }

        
    }
}
