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
        private static HomeVM instance;//Единственный объект класса в соответствии с паттерном Singleton

        /*метод создающий единственный объект класса, если он ещё не создан или возвращает существующий*/
        public static HomeVM GetInstance()
        {
            if (instance == null)
                instance = new HomeVM();
            return instance;
        }


        public delegate void NextPage();
        public event NextPage dataButton;//event хранит методы подписанные на событие Data_btn_click
        public event NextPage settingsButton;//event хранит методы подписанные на событие Settings_btn_click
        public event NextPage singOut;//event хранит методы подписанные на событие singOut_btn_click
        public HomeCommands DataButton { get; private set; }
        public HomeCommands SettingsButton { get; private set; }
        public HomeCommands SingOut { get; private set; }

        private HomeVM()
        {
            DataButton = new HomeCommands(Data_btn_click);
            SettingsButton = new HomeCommands(Settings_btn_click);
            SingOut = new HomeCommands(SingOut_btn_click);
            dataButton = () => { };
            settingsButton = () => { };
            singOut = () => { };
        }

        /*Событие нажатие на кнопку Data*/
        public void Data_btn_click()
        {
           dataButton();
        }

        /*Событие нажатие на кнопку Settings*/
        public void Settings_btn_click()
        {
            settingsButton();
        }

        /*Событие нажатие на кнопку SingOut*/
        public void SingOut_btn_click()
        {
            singOut();
        }

    }
}
