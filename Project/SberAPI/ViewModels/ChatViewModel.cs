using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberAPI.ViewModels
{
    [Serializable]
    public class ChatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public int TypeId { get; set; }
        public int? AdminId { get; set; }

        public List<MessageViewModel> Messages { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
