using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.ViewModels.DataViewModels
{
    class DataVM : BaseVM
    {
        public DataVM()
        {
            MenuItemsData = new ObservableCollection<MenuItemDataVM>()
            {
                new MenuItemDataVM("Дети", new ChildrenDataVM()),
                new MenuItemDataVM("Блюда", new DishListDataVM())
            };
        }
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
    }

    
}
