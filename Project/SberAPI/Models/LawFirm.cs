using System;
using System.Collections.Generic;

#nullable disable

namespace SberAPI.Models
{
    public partial class LawFirm
    {
        public LawFirm()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public long Psrn { get; set; }
        public long Inn { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
