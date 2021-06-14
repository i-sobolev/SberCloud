using SberCloudWpf.AppData;
using SberCloudWpf.Model;
using SberCloudWpf.View;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SberCloudWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserViewModel _user;
        public MainWindow(UserViewModel user = null)
        {
            InitializeComponent();
            _user = user;

            PermanentData.Frame = MainFrame;
            PermanentData.Frame.Navigate(new MessagePage(_user));
        }

        private void BtnRollUp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.Frame.Navigate(new MessagePage(_user));

        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            Close();
        }

        private void BtnPersonal_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.Frame.Navigate(new PersonalPage(_user));
        }

        private void BtnContacts_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.Frame.Navigate(new ContactsPage(_user));
        }
    }
}
