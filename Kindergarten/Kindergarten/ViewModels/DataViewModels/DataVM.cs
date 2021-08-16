using Kindergarten.ViewModels.Commands;
using Kindergarten.ViewModels.DataViewModels.PagesViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.ViewModels.DataViewModels
{
    public class DataVM : BaseVM
    {
        #region Constructor
        private static DataVM instance;
        public static DataVM GetInstance()
        {
            if (instance == null)
                instance = new DataVM();
            return instance;
        }
        private DataVM()
        {
            #region CreateListOfPages
            MenuItemsData = new ObservableCollection<MenuItemDataVM>()
            {
                new MenuItemDataVM("Дети", ChildrenDataVM.GetInstanse()),
                new MenuItemDataVM("Блюда", new DishListDataVM()),
                new MenuItemDataVM("Сотрудники", EmployeeDataVM.GetInstanse()),
                new MenuItemDataVM("Пользователи", UserDataVM.GetInstanse())
            };
            #endregion //CreateListOfPages

            #region CreateEventClickButton

            backspaceButton = () => { };
            BackspaceButtonClick = new MenuItemDataCommand(Backspace_btn_click);

            #endregion //CreateEventClickButton
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
