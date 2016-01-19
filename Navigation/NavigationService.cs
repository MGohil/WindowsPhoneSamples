using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Navigation
{
    public interface INavigationService
    {
        void Navigate(Type sourcePageType);
        void Navigate(Type sourcePageType, object parameter);
        void GoBack();
    }

    /// <summary>
    /// This class will handle the non-linear navigation of the pages.
    /// It will prevent the same page to be navigated again and again in the navigation stack
    /// 
    /// </summary>
    public class NavigationService : INavigationService
    {
        private NavigationService()
        {

        }

        private static Lazy<NavigationService> _lazyInstance = new Lazy<NavigationService>(() => new NavigationService());

        public static NavigationService Instance
        {
            get
            {
                try
                {
                    _lazyInstance.Value.ToString();
                    return _lazyInstance.Value;
                }
                catch (Exception)
                {
                    return _lazyInstance.Value;
                }
            }
        }

        public void Navigate(Type sourcePageType)
        {
            NonLinearNavigate(sourcePageType);
        }

        public void Navigate(Type sourcePageType, object parameter)
        {
            NonLinearNavigate(sourcePageType, parameter);
        }

        private void NonLinearNavigate(Type sourcePageType, object parameter = null)
        {
            try
            {
                var backStackPageList = App.RootFrame.BackStack.ToList().Select(x => x.Source.OriginalString).ToList();
                int targetPageIndex = backStackPageList.IndexOf(backStackPageList.Where(x => x == ("/Views/" + sourcePageType.Name + ".xaml")).FirstOrDefault());

                if (backStackPageList.Contains(PagePath(sourcePageType)))
                {
                    for (int i = 1; i <= (targetPageIndex); i++)
                    {
                        App.RootFrame.RemoveBackEntry();
                    }
                    GoBack();
                }
                else
                {
                    var currentPageType = App.RootFrame.Content.GetType();
                    if (currentPageType != sourcePageType)
                    {
                        SimplyNavigate(sourcePageType, parameter);
                    }
                }
            }
            catch
            {
                SimplyNavigate(sourcePageType, parameter);
            }
        }

        private void SimplyNavigate(Type sourcePageType, object parameter)
        {
            if (parameter == null)
            {
                App.RootFrame.Navigate(new Uri(PagePath(sourcePageType), UriKind.Relative));
            }
            else
            {
                App.RootFrame.Navigate(new Uri(PagePath(sourcePageType) + "?key=" + parameter, UriKind.Relative));

            }
        }

        public void GoBack()
        {
            if (App.RootFrame.CanGoBack && App.RootFrame.BackStack.Count() > 0)
                App.RootFrame.GoBack();
            else
                Application.Current.Terminate();
        }

        public void ClearBackStack(PhoneApplicationPage page)
        {
            while (page.NavigationService.RemoveBackEntry() != null) ;
        }

        private string PagePath(Type sourcePageType)
        {
            return "/Views/" + sourcePageType.Name + ".xaml";
        }
    }
}
