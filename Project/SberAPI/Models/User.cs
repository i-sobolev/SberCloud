using System;
using System.Collections.Generic;

#nullable disable

namespace SberAPI.Models
{
    public partial class User
    {
        public User()
        {
            ChatUsers = new HashSet<ChatUser>();
            Chats = new HashSet<Chat>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public int CountryId { get; set; }
        public string IpAddress { get; set; }
        public int RegionId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? LawFirmId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }

        public virtual Country Country { get; set; }
        public virtual LawFirm LawFirm { get; set; }
        public virtual Region Region { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<ChatUser> ChatUsers { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
