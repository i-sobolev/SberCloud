using SberAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Chat FromViewModel(ChatViewModel chat)
        {
            return new Chat()
            {
                AdminId = chat.AdminId,
                Admin = Data.SberCloudContext.Users.Where(x => x.Id == AdminId).FirstOrDefault(),

                TypeId = chat.TypeId,
                Type = Data.SberCloudContext.Types.Where(x => x.Id == TypeId).FirstOrDefault(),

                Id = chat.Id,
                Name = chat.Name,
                DateCreated = chat.DateCreated
            };
        }

        public ChatViewModel ToViewModel()
        {
            return new ChatViewModel()
            {
                AdminId = AdminId,
                TypeId = TypeId,
                Id = Id,
                Name = Name,
                DateCreated = DateCreated
            };
        }
    };
}