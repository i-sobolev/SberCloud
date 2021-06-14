using SberCloudWpf.Model;
using SberCloudWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCloudWpf.AppData
{
    public class Chat
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public MessageViewModel Message { get; set; }
    }
}
