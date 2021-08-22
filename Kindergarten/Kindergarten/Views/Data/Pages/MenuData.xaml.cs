using Kindergarten.ViewModels.DataViewModels.PagesViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kindergarten.Models.Entities;

namespace Kindergarten.Views.Data.Pages
{
    /// <summary>
    /// Interaction logic for MenuData.xaml
    /// </summary>
    public partial class MenuData : UserControl
    {
        public MenuData()
        {
            InitializeComponent();
            DataContext = MenuDataVM.GetInstanse();
        }

        private void Menus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menu = Menus.SelectedValue;
            var mdvm = MenuDataVM.GetInstanse();

            mdvm.SetDishes();
            mdvm.SetMenus();

            mdvm.SelectedMenu = (Models.Entities.Menu)menu;
            mdvm.GetDishes();
        }

        private void Dishes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dish = Dishes.SelectedValue;
            var mdvm = MenuDataVM.GetInstanse();

            mdvm.SetDishItems();
            mdvm.SetDishes();

            mdvm.SelectedDish = (Models.Entities.Dish)dish;
            mdvm.GetDishItems();
        }
    }
}
