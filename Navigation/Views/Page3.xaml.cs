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
    public partial class Page3 : PhoneApplicationPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigationService.Instance.GoBack();
        }       
        private void GoToMainPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigationService.Instance.Navigate(typeof(MainPage));
        }
    }
}