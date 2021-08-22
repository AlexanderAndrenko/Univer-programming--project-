using Kindergarten.Models;
using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    public class MenuDataVM : BaseVM
    {
        #region Constructor

        private static MenuDataVM instanse;

        public static MenuDataVM GetInstanse()
        {
            if (instanse == null)
                instanse = new MenuDataVM();
            return instanse;
        }

        private MenuDataVM()
        {
            GetMenus();
            SelectedMenu = DataGridMenus.First();
            GetDishes();
            SelectedDish = DataGridDishes.FirstOrDefault();
            if(SelectedDish != null)
                GetDishItems();
            Products = ProductsModel.GetProducts();
        }

        #endregion //Constructor

        #region Properties

        private List<Menu> menus;
        public List<Menu> DataGridMenus 
        { 
            get => menus;
            set
            {
                menus = value;
                RaisePropertyChanged();
            } 
        }
        public List<int> MenuIds { get; set; }
        public Menu SelectedMenu { get; set; }

        private List<Dish> dishes;
        public List<Dish> DataGridDishes 
        { 
            get => dishes;
            set
            {
                dishes = value;
                RaisePropertyChanged();
            }
        }
        public List<int> DishIds { get; set; }
        public Dish SelectedDish { get; set; }

        private List<DishItem> dishItems;
        public List<DishItem> DataGridDishItems 
        {
            get => dishItems;
            set
            {
                dishItems = value;
                RaisePropertyChanged();
            }
        }
        public List<int> DishItemsIds { get; set; }
        public List<Product> Products { get; set; }

        #endregion //Properties

        #region Methods

        public void GetMenus()
        {
            DataGridMenus = MenuModel.GetMenus();
            if (MenuIds != null)
                MenuIds.Clear();
            MenuIds = DataGridMenus.Select(x => x.Id).ToList();
        }

        public void GetDishes()
        {
            DataGridDishes = DishModel.GetDishes(SelectedMenu.Id);
            if (DishIds != null)
                DishIds.Clear();
            DishIds = DataGridDishes.Select(x => x.Id).ToList();
        }

        public void GetDishItems()
        {
            DataGridDishItems = DishItemModel.GetDishItems(SelectedDish.Id);
            if (DishItemsIds != null)
                DishItemsIds.Clear();
            DishItemsIds = DataGridDishItems.Select(x => x.Id).ToList();
        }

        public void SetMenus()
        {
            MenuModel.SetMenus(DataGridMenus, MenuIds);
            GetMenus();
        }

        public void SetDishes()
        {
            DishModel.SetDishes(DataGridDishes, DishIds);
            if (DishIds != null)
                DishIds.Clear();
        }

        public void SetDishItems()
        {
            DishItemModel.SetDishItems(DataGridDishItems, DishItemsIds);
            if (DishItemsIds != null)
                DishItemsIds.Clear();
        }

        #endregion //Methods

        //private class IdList
        //{
        //    public IdList(int menuId, List<int> DishId, Li)
        //    {

        //    }

        //    public int MenuId;

        //    public List<DishIds> DishId;

        //    public class DishIds
        //    {
        //        public DishIds()
        //        {

        //        }

        //        public List<int> DishItemId;
        //    }
        //}
    }
}
