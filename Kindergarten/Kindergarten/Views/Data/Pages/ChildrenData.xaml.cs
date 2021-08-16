using Kindergarten.ViewModels.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kindergarten.Views.Data
{
    /// <summary>
    /// Interaction logic for ChildrenData.xaml
    /// </summary>
    public partial class ChildrenData : UserControl
    {
        public ChildrenData()
        {
            InitializeComponent();
            DataContext = ChildrenDataVM.GetInstanse();
            SD.SelectedDate = DateTime.Today;
            ED.SelectedDate = DateTime.Today;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (SingleSelect.Visibility == Visibility.Visible)
            {
                SingleSelect.Visibility = Visibility.Hidden;
                MultipleSelect.Visibility = Visibility.Visible;
            }
            else
            {
                SingleSelect.Visibility = Visibility.Visible;
                MultipleSelect.Visibility = Visibility.Hidden;
            }
        }
    }
}
