using System;
using System.Collections.Generic;

#nullable disable

namespace SberAPI.Models
{
    public partial class ChatUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual User User { get; set; }
    }
}
