using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Post
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int Like { get; set; }
        public int ViewCount { get; set; }

        public Post(int id, string content)
        {
            ID = id;
            Content = content;
            DateTime = DateTime.Now;
            Like = 0;
            ViewCount = 0;
        }
        public void DeletePost()
        {

        }
        public void ShowPost()
        {
            Console.WriteLine($"ID : {ID}");
            Console.WriteLine($"Content : {Content}");
            Console.WriteLine($"Datetime : {DateTime}\t\t\t\t\tLikes : {Like}");
            Console.WriteLine($"\t\t\tView : {ViewCount}");
        }
    }
}
