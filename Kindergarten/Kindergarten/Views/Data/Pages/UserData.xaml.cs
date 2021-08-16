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
    /// Interaction logic for UserData.xaml
    /// </summary>
    public partial class UserData : UserControl
    {
        public UserData()
        {
            InitializeComponent();
            DataContext = UserDataVM.GetInstanse();
        }
    }
}
