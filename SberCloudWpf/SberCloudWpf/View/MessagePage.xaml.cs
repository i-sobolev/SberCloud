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
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        private UserViewModel _user;
        private UserViewModel _selectedUser;

        public MessagePage(UserViewModel user = null, UserViewModel selectedUser = null)
        {
            InitializeComponent();

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

            //ListLastMessages.ItemsSource = user.ToList();
            //ListContacts.ItemsSource = user.ToList();

            //ListMessage.ItemsSource = user.ToList();
            #endregion
            _user = user;
            _selectedUser = selectedUser;

            GetChats();            

            PermanentData.FrameMessage = MessageFrame;
            PermanentData.FrameMessage.Navigate(new DefaultPage());

            PermanentData.UserId = user.Id;

            
        }

        //private async Task GetMessages()
        //{
        //    Chats = new List<Chat>();

        //    _chatUser.ForEach(async chatUser =>
        //    {
        //        try
        //        {
        //            string url = $"http://makievksy.ru.com/Message?chatId={chatUser.Chat.Id}";
        //            HttpClient client = new HttpClient();

        //            var response = await client.GetAsync(url);
        //            var responseContent = await response.Content.ReadAsStringAsync();

        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                var messages = JsonConvert.DeserializeObject<List<MessageViewModel>>(responseContent);

        //                var newChat = new Chat()
        //                {
        //                    Id = chatUser.Id,
        //                    Messages = messages,
        //                    Users = chatUser.User
        //                };

        //                Chats.Add(newChat);
        //                ListLastMessages.ItemsSource = Chats;
        //            }

        //            else
        //                throw new Exception();
        //        }
        //        catch (Exception er)
        //        {
        //            er.Message.ToString();
        //        }
        //    });
        //}

        //private async void GetChat()
        //{
        //    try
        //    {
        //        List<Chat> chats = new 
        //    }
        //    catch (Exception er)
        //    {

        //        er.Message.ToString();
        //    }
        //}

        private List<ChatViewModel> _chatUser;

        private async void GetChats()
        {
            try
            {
                string url = $"http://makievksy.ru.com/Chat?userId={_user.Id}";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _chatUser = JsonConvert.DeserializeObject<List<ChatViewModel>>(responseContent);
                    ListLastMessages.ItemsSource = _chatUser.ToList();
                    ListContacts.ItemsSource = _chatUser.ToList();

                    if (_selectedUser != null)
                    {
                        PermanentData.FrameMessage = MessageFrame;
                        PermanentData.FrameMessage.Navigate(new TextMessagePage(_chatUser.LastOrDefault(), _user));
                    }

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

        private void ListLastMessages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedChat = ListLastMessages.SelectedItem as ChatViewModel;

            PermanentData.FrameMessage = MessageFrame;
            PermanentData.FrameMessage.Navigate(new TextMessagePage(selectedChat, _user));
        }

        private void TxtSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ListLastMessages.ItemsSource = _chatUser.Where(x => x.Users[1].FirstName.Contains(TxtSearch.Text) | x.Users[1].MiddleName.Contains(TxtSearch.Text)).ToList();
        }
    }
}
