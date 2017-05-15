﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SpotTerm.Model;
using SpotTerm.ViewModel;

namespace SpotTerm.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MapPage : Page
    {
        private readonly MapPageViewModel _viewModel;

        public MapPage(String address)
        {
            InitializeComponent();
            _viewModel = new MapPageViewModel(address);
            this.DataContext = _viewModel;
        }

    }
}