using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberAPI.ViewModels
{
    public class ChatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public int TypeId { get; set; }
        public int? AdminId { get; set; }
    }
}
