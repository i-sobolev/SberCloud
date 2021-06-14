using Newtonsoft.Json;
using SberCloudWpf.AppData;
using SberCloudWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace SberCloudWpf.View
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private UserViewModel _user;
        private async void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EmptyFieldValidation.IsFieldEmpty(TxtLogin.Text, TxtPassword.Password))
                {
                    DefaultMessage.WarningMessage("Заполните все поля данными");
                }
                else
                {
                    string url = $"http://makievksy.ru.com/Auth?login={TxtLogin.Text}&password={TxtPassword.Password}";
                    HttpClient client = new HttpClient();

                    var response = await client.GetAsync(url);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        _user = JsonConvert.DeserializeObject<UserViewModel>(responseContent);
                        MainWindow mainWindow = new MainWindow(_user);
                        mainWindow.Show();

                        Close();
                    }
                    else
                    {
                        DefaultMessage.WarningMessage("Такого пользователя не существует!");
                    }
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message.ToString());
            }
        }

        private void TxtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtPasswordHint.Visibility = Visibility.Collapsed;
        }

        private void TxtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPassword.Password))
                TxtPasswordHint.Visibility = Visibility.Collapsed;
            else
                TxtPasswordHint.Visibility = Visibility.Visible;
        }

        private void TxtLogin_GotFocus(object sender, RoutedEventArgs e)
        {

            TxtLoginHint.Visibility = Visibility.Collapsed;
        }

        private void TxtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtLogin.Text))
                TxtLoginHint.Visibility = Visibility.Collapsed;
            else
                TxtLoginHint.Visibility = Visibility.Visible;
        }

        private void BtnSber_Click(object sender, RoutedEventArgs e)
        {
            SberIDWindow sberIDWindow = new SberIDWindow();
            sberIDWindow.Show();

            Close();
        }
    }
}
