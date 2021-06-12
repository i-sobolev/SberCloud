using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberAPI.ViewModels
{
    [Serializable]
    public class UserViewModel
    {
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
    }
}
