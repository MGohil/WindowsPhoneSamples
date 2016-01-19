using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Navigation
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigationService.Instance.GoBack();
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