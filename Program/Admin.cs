using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Admin
    {

        public static int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Post> posts { get; set; }
        public string notification { get; set; }
        
        
        public Admin(string username, string email, string password)
        {
            id++;
            this.username = username;
            this.email = email;
            this.password = password;
        }

        public void AddPost(Post post)
        {
            posts.Add(post);
        }
        public void DeletePostByIndex(int i)
        {
            posts.RemoveAt(i);
        }
        public void DeleteAllPosts()
        {
            posts.Clear();
        }
        public string GetNotification()
        {
            Console.Beep();
            return notification;
        }
        public void ShowPosts()
        {
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.DateTime} : {post.Content}");
                Console.WriteLine($"Likes : {post.Like}\t\t\tView : {post.ViewCount}");
            }
        }
    


    }
}
