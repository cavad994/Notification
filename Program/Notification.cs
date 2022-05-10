using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Notification
    {
        public int id { get; set; }
        public string Text { get; set; }
        public DateTime dateTime { get; set; }
        public User User { get; set; }

        public Notification(){}
        public Notification(string text,User user) 
        {
            Text = text;
            User = user;
            dateTime = DateTime.Now;
        }

        public string GetNotification()
        {
            return ($" liked your post! \t\t{dateTime}");
        }
    }
}
