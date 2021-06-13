using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberAPI.ViewModels
{
    public class MessageViewModel
    {
        public int tId { get; set; }
        public UserViewModel User { get; set; }
        public string Text { get; set; }
        public ChatViewModel Chat { get; set; }
        public string TimeStamp { get; set; }
    }
}
