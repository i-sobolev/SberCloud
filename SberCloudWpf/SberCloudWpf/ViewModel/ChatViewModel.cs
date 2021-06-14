using SberCloudWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCloudWpf.ViewModel
{
    public class ChatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public int TypeId { get; set; }
        public int? AdminId { get; set; }

        public List<MessageViewModel> Messages { get; set; }
        public List<UserViewModel> Users { get; set; }

        public string GetUserName
        {
            get
            {
                if (Users != null)
                    return $"{Users[1].FirstName} {Users[1].LastName}";

                return null;

            }
        }


        public string LastMessage
        {
            get
            {
                if (Messages != null)
                    return $"{Messages[Messages.Count - 1].Text}";

                else
                    return null;

            }
        }

        public string Date
        {
            get
            {
                if (Messages == null)
                    return null;


                System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                var timeStamp = Convert.ToDouble(Messages[Messages.Count - 1].TimeStamp);

                var date = dateTime.AddSeconds(timeStamp).ToLocalTime();
                return $"{date.Month}.{date.Day} {date.Hour}:{date.Minute}";

            }
        }
    }
}
