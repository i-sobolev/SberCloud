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
    /// Логика взаимодействия для PersonalPage.xaml
    /// </summary>
    public partial class PersonalPage : Page
    {
        private UserViewModel _user;
        public PersonalPage(UserViewModel user = null)
        {
            InitializeComponent();

            DataContext = user;
            _user = user;

            #region TestData
            //List<UserViewModel> _user = new List<UserViewModel>()
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
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1
            //    },
            //    new UserViewModel()
            //    {
            //        Id = 6,
            //        FirstName = "Test",
            //        LastName = "Textajknfljaw lawndl lanl awld lawndln lkanwdwndlad. Textajknfljaw lawndl lanl awld lawndln lkanwdwndlad. Textajknfljaw lawndl lanl awld lawndln lkanwdwndlad.",
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
            //    },new UserViewModel()
            //    {
            //        Id = 6,
            //        FirstName = "Test",
            //        LastName = "Test",
            //        MiddleName = "Test",
            //        CountryId = 1

            //    }
            //};

            //DataContext = _user;
            #endregion

            GetCountryData();
        }

        private List<CountryViewModel> _country;
        private async void GetCountryData()
        {
            try
            {
                string url = "http://makievksy.ru.com/Country";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _country = JsonConvert.DeserializeObject<List<CountryViewModel>>(responseContent);
                    CmbxCountry.ItemsSource = _country.ToList();
                    CmbxCountry.SelectedValuePath = "Id";
                    CmbxCountry.DisplayMemberPath = "Name";

                    CmbxCountry.Text = _country.Where(x => x.Id == _user.CountryId).Select(x => x.Name).FirstOrDefault();
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        /// <summary>
        /// Редактирование данных авторизованного пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EmptyFieldValidation.IsFieldEmpty(TxtFirstName.Text, TxtMiddleName.Text, TxtEmail.Text, TxtLogin.Text, TxtPhone.Text, TxtUserName.Text))
                {
                    DefaultMessage.WarningMessage("Все поля должны быть заполнены!");
                }
                else
                {
                    string url = "http://makievksy.ru.com/User";
                    HttpClient client = new HttpClient();

                    var request = new UserViewModel()
                    {
                        Id = _user.Id,
                        FirstName = TxtFirstName.Text,
                        MiddleName = TxtMiddleName.Text,
                        Email = TxtEmail.Text,
                        CountryId = Convert.ToInt32(CmbxCountry.SelectedValue),
                        Phone = TxtPhone.Text,
                        Login = TxtLogin.Text
                    };

                    var requestJson = JsonConvert.SerializeObject(request);
                    StringContent sc = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(url, sc);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        DefaultMessage.InformationMessage("Данные успешно изменены!");
                    }
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }
    }
}
