﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Zanimljiva_Geografija_Tim14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Collection<Country> _countries;
        private readonly CountryService _service;

        public MainWindow()
        {
            InitializeComponent();
            _service = new CountryService();
            _ = LoadCountriesAsync();
        }

        public async Task LoadCountriesAsync()
        {
            try
            {
                _countries = new ObservableCollection<Country>(await _service.GetCountriesAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new ComparisonWindow(new List<Country>() { _countries[0], _countries[1] });
            Hide();
            window.ShowDialog();
            Show();
        }
    }
}
