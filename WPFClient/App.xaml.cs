using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            NavigationWindow navWindow = new NavigationWindow
            {
                Content = new WelcomePage(),
                WindowState = WindowState.Maximized,
                WindowStyle = WindowStyle.SingleBorderWindow, // keep title bar + min/max/close buttons
                ShowsNavigationUI = false                     // hide the back/forward navigation bar
            };

            navWindow.Show();
        }
    }

}
