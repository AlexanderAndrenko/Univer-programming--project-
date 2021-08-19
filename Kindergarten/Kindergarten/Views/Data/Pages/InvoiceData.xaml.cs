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

namespace Kindergarten.Views.Data.Pages
{
    /// <summary>
    /// Interaction logic for InvoiceData.xaml
    /// </summary>
    public partial class InvoiceData : UserControl
    {
        public InvoiceData()
        {
            InitializeComponent();
            DataContext = InvoiceDataVM.GetInstanse();
        }
    }
}
