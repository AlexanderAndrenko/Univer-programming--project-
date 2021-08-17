﻿using Kindergarten.ViewModels.DataViewModels.PagesViewModel;
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
    /// Interaction logic for SupplierData.xaml
    /// </summary>
    public partial class SupplierData : UserControl
    {
        public SupplierData()
        {
            InitializeComponent();
            DataContext = SupplierDataVM.GetInstanse();
        }
    }
}
