using System;
using System.Collections.Generic;

#nullable disable

namespace SberAPI.Models
{
    public partial class Chat
    {
        public Chat()
        {
            ChatUsers = new HashSet<ChatUser>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public int TypeId { get; set; }
        public int? AdminId { get; set; }

        public virtual User Admin { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<ChatUser> ChatUsers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
