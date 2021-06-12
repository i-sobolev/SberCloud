using Newtonsoft.Json;
using SberAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public virtual Country Country { get; set; }
        public virtual LawFirm LawFirm { get; set; }
        public virtual Region Region { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<ChatUser> ChatUsers { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        public UserViewModel ToViewModel()
        {
            return new UserViewModel()
            {
                Login = Login,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName,
                Email = Email,
                Phone = Phone,
                LawFirmId = LawFirmId,
                IpAddress = IpAddress,
                RegionId = RegionId,
                CountryId = CountryId,
                RoleId = RoleId,
            };
        }
        public User FromViewModel(UserViewModel user)
        {
            return new User()
            {
                Login = user.Login,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Email = user.Email,
                Phone = user.Phone,
                LawFirmId = user.LawFirmId,
                IpAddress = user.IpAddress,
                RegionId = user.RegionId,
                CountryId = user.CountryId,
                RoleId = user.RoleId,
                Country = Data.SberCloudContext.Countries.Where(x => x.Id == user.CountryId).FirstOrDefault(),
                Role = Data.SberCloudContext.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault(),
                Region = Data.SberCloudContext.Regions.Where(x => x.Id == user.RegionId).FirstOrDefault(),
                LawFirm = Data.SberCloudContext.LawFirms.Where(x => x.Id == user.LawFirmId).FirstOrDefault()
            };
        }
    }
}
