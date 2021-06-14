using Newtonsoft.Json;
using SberCloudWpf.AppData;
using SberCloudWpf.Model;
using SberCloudWpf.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SberCloudWpf.View
{
    /// <summary>
    /// Логика взаимодействия для ContactsPage.xaml
    /// </summary>
    public partial class ContactsPage : Page
    {
        private UserViewModel _userData;
        public ContactsPage(UserViewModel user)
        {
            InitializeComponent();
            _userData = user;
            #region TestData
            //List<UserViewModel> user = new List<UserViewModel>()
            //{
            //    new UserViewModel()
            //    {
            //        Id = 1,
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 2,
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 3,
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 4,
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 5,
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 6,
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 6,
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 6,
            //        FirstName = "April",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 6,
            //        FirstName = "Low",
            //        LastName = "Textajknfljaw lawndl lanl awld lawndln lkanwdwndlad. Textajknfljaw lawndl lanl awld lawndln lkanwdwndlad. Textajknfljaw lawndl lanl awld lawndln lkanwdwndlad.",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 6,
            //        FirstName = "Name",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },new UserViewModel()
            //    {
            //        Id = 6,
            //        FirstName = "Tom",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1

            //    }
            //};

            //ListContacts.ItemsSource = user.OrderBy(x => x.FirstName).Where(x => x.FirstName.Substring(0, 1) == x.GetLetter).ToList();
            #endregion

            GetUserData();

        }

        private List<UserViewModel> _user;
        private async void GetUserData()
        {
            try
            {
                string url = "http://makievksy.ru.com/User";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _user = JsonConvert.DeserializeObject<List<UserViewModel>>(responseContent);
                    ListContacts.ItemsSource = _user.OrderBy(x => x.FirstName).Where(x => x.FirstName.Substring(0, 1) == x.GetLetter).ToList();
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        private void TxtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSearch.Text))
                TxtSearchHint.Visibility = Visibility.Collapsed;
            else
                TxtSearchHint.Visibility = Visibility.Visible;

        }

        private void TxtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtSearchHint.Visibility = Visibility.Collapsed;
        }

        private void IconClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TxtSearch.Text = string.Empty;
        }

        private async void BtnMessage_Click(object sender, RoutedEventArgs e)
        {
            int unixTime = Convert.ToInt32((DateTime.Now - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
            string unix = unixTime.ToString();

            string url = "http://makievksy.ru.com/Chat";
            HttpClient httpClient = new HttpClient();

            var request = new ChatViewModel()
            {
                Name = _selectedUser.MiddleName,
                DateCreated = unix,
                TypeId = 1,
                AdminId = _userData.Id
            };

            var requestJson = JsonConvert.SerializeObject(request);
            StringContent sc = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, sc);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                PermanentData.Frame.Navigate(new MessagePage(_userData, _selectedUser));
        }

        private void TxtSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ListContacts.ItemsSource = _user.OrderBy(x => x.FirstName).Where(x => x.FirstName.Substring(0, 1) == x.GetLetter && x.FirstName.Contains(TxtSearch.Text)
            | x.MiddleName.Contains(TxtSearch.Text)).ToList();
        }

        private UserViewModel _selectedUser;
        private void ListContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedUser = ListContacts.SelectedItem as UserViewModel;

            DataContext = _selectedUser;
        }
    }
}
