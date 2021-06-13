using SberAPI.ViewModels;
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

        public ChatUserViewModel ToViewModel()
        {
            return new ChatUserViewModel()
            {
                Id = Id,
                User = new UserViewModel() 
                {
                    Id = UserId,
                    FirstName = User.FirstName,
                    MiddleName = User.MiddleName
                },
                Chat = new ChatViewModel() 
                {
                    Name = Chat.Name,
                    DateCreated = Chat.DateCreated,
                    TypeId = Chat.TypeId,
                    AdminId = Chat.AdminId
                }
            };
        }
    }
}
