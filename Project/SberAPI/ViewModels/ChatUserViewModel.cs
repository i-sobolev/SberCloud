using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberAPI.ViewModels
{
    [Serializable]
    public class ChatUserViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public ChatViewModel Chat { get; set; }
    }
}
