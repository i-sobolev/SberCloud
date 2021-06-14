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
    /// Логика взаимодействия для TextMessagePage.xaml
    /// </summary>
    public partial class TextMessagePage : Page
    {
        private ChatViewModel _chat;
        private UserViewModel _user;

        public TextMessagePage(ChatViewModel chat, UserViewModel user)
        {
            InitializeComponent();
            _chat = chat;
            _user = user;

            DataContext = chat;


            ListMessage.ItemsSource = chat.Messages;
        }

        private void TxtMessage_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtMessage.Text))
                TxtMessageHint.Visibility = Visibility.Collapsed;
            else
                TxtMessageHint.Visibility = Visibility.Visible;
        }

        private void TxtMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtMessageHint.Visibility = Visibility.Collapsed;
        }

        private async void BtnSend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int unixTime = Convert.ToInt32((DateTime.Now - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
                string unix = unixTime.ToString();

                string url = $"http://makievksy.ru.com/Message?text={TxtMessage.Text}&userId={_user.Id}&chatId={_chat.Id}&timestamp={unix}";
                HttpClient client = new HttpClient();

                var response = await client.PostAsync(url, null);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    GetChats();
                    TxtMessage.Text = string.Empty;
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

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
                    ListMessage.ItemsSource = _chatUser.Where(x => x.Id == _chat.Id).FirstOrDefault().Messages.ToList();
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }
    }
}
