using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Navigation.Resources;

namespace Navigation
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToPageOne_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigationService.Instance.Navigate(typeof(Page1));
        }
        private void GoToPageTwo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigationService.Instance.Navigate(typeof(Page2));
        }
        private void GoToPageThree_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigationService.Instance.Navigate(typeof(Page3));
        }
        private void GoToMainPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigationService.Instance.Navigate(typeof(MainPage));
        }
    }
}