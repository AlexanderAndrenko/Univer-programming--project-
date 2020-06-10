using Kindergarten.ViewModels.Commands;
using Kindergarten.ViewModels.SettingsViewModels.PagesViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.ViewModels.SettingsViewModels
{
    public class SettingsVM : BaseVM
    {
        #region Constructor
        private static SettingsVM instance;

        public static SettingsVM GetInstance()
        {
            if (instance == null)
                instance = new SettingsVM();
            return instance;
        }
        private SettingsVM()
        {
            MenuItemsData = new ObservableCollection<MenuItemDataVM>()
            {
                new MenuItemDataVM("Дети Set", new ChildrenSetVM()),
                new MenuItemDataVM("Блюда Set", new DishListSetVM())
            };

            backspaceButton = () => { };
            BackspaceButtonClick = new MenuItemDataCommand(Backspace_btn_click);
        }
        #endregion //Constructor

        #region backspace button

        public delegate void BackspaceButtonDelegate();
        public event BackspaceButtonDelegate backspaceButton;
        public MenuItemDataCommand BackspaceButtonClick { get; set; }

        private void Backspace_btn_click()
        {
            backspaceButton();
        }

        #endregion //backspace button

        #region ListBoxItem
        public ObservableCollection<MenuItemDataVM> MenuItemsData { get; set; }

        private BaseVM currentContent;
        public BaseVM CurrentContent
        {
            get => currentContent;
            set
            {
                currentContent = value;
                RaisePropertyChanged();
            }
        }

        private MenuItemDataVM selectedMenu;
        public MenuItemDataVM SelectedMenu
        {
            get => selectedMenu;
            set
            {
                selectedMenu = value;
                CurrentContent = value.ViewModel;
                RaisePropertyChanged();
            }
        }
        #endregion //ListBoxItem

        private string _userNameSurname;
        public string UserNameSurname
        {
            get => _userNameSurname;
            set
            {
                _userNameSurname = value;
                RaisePropertyChanged();
            }
        }
    }
}
