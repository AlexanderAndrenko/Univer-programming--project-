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
using System.Windows.Shapes;
using Kindergarten.Models.Entities;
using Menu = Kindergarten.Models.Entities.Menu;

namespace Kindergarten.Views.Data.Pages
{
    /// <summary>
    /// Interaction logic for ExpenseForNutrition.xaml
    /// </summary>
    public partial class ExpenseForNutrition : Window
    {
        public ExpenseForNutrition()
        {
            InitializeComponent();
            DataContext = CreateExpenseForNutritionVM.GetInstanse();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = comboBox.SelectedItem;
            var ExpenseForNutrution = CreateExpenseForNutritionVM.GetInstanse();
            ExpenseForNutrution.SelectedMenu = (Menu)selectedItem;
        }
    }
}
