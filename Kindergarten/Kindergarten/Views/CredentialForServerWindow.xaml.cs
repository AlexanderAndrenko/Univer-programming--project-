﻿using System;
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
using System.Windows.Shapes;
using Kindergarten.ViewModels;

namespace Kindergarten.Views
{
    /// <summary>
    /// Interaction logic for CredentialForServerWindow.xaml
    /// </summary>
    public partial class CredentialForServerWindow : Window
    {
        public CredentialForServerWindow()
        {
            InitializeComponent();
            DataContext = CredentialForServerVM.GetInstance();
        }
    }
}
