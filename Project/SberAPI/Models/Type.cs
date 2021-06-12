using System;
using System.Collections.Generic;

#nullable disable

namespace SberAPI.Models
{
    public partial class Type
    {
        public Type()
        {
            Chats = new HashSet<Chat>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
    }
}
