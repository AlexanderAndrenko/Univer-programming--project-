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
using Kindergarten.ViewModels.DataViewModels.PagesViewModel;

namespace Kindergarten.Views.Data.Pages
{
    /// <summary>
    /// Interaction logic for InvoiceCreateNew.xaml
    /// </summary>
    public partial class InvoiceCreateNew : Window
    {
        public InvoiceCreateNew()
        {
            InitializeComponent();
            DataContext = InvoiceCreateNewVM.GetInstanse();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = comboBox.SelectedItem;
            var invoiceCreateNew = InvoiceCreateNewVM.GetInstanse();
            invoiceCreateNew.Supplier = (Supplier)selectedItem;
        }
    }
}
