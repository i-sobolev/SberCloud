using SberCloudWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCloudWpf.ViewModel
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public string Text { get; set; }
        public ChatViewModel Chat { get; set; }
        public string TimeStamp { get; set; }

        public string GetUserName
        {
            get
            {
                if (User == null)
                    return null;
                else
                    return $"{User.FirstName} {User.MiddleName}";
            }
        }
    }
}
