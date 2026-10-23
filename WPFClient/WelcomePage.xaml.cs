using Model;
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
using ViewModel;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("אנא הכנס שם משתמש וסיסמה.", "שגיאה");
                return;
            }
            UserDB userDB = new UserDB();


            if (userDB.Login(username, password) == null)
            {
                MessageBox.Show("אימייל או סיסמה שגויים.", "שגיאה");
                return;
            }

            else
            {
               User u = new User();
                u = userDB.Login(username, password);

                if (u.UserType == "Provider")
                {
                    ProviderDB providerDB = new ProviderDB();
                    Provider p = providerDB.GetById(u.Id); 
                }
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
