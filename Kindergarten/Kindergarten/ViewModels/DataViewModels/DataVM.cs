﻿using Kindergarten.ViewModels.Commands;
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
                new MenuItemDataVM("Шаблоны меню", MenuDataVM.GetInstanse()),
                new MenuItemDataVM("Сотрудники", EmployeeDataVM.GetInstanse()),
                new MenuItemDataVM("Пользователи", UserDataVM.GetInstanse()),
                new MenuItemDataVM("Поставщики", SupplierDataVM.GetInstanse()),
                new MenuItemDataVM("Продукты", ProductsDataVM.GetInstanse()),
                new MenuItemDataVM("Накладные", InvoiceDataVM.GetInstanse()),
                new MenuItemDataVM("Партии", PartyDataVM.GetInstanse()),
                new MenuItemDataVM("Документы", DocumentDataVM.GetInstanse())
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
