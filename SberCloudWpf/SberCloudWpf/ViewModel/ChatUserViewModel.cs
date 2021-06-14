using SberCloudWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCloudWpf.ViewModel
{
    public class ChatUserViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public ChatViewModel Chat { get; set; }
    }
}
