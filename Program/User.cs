using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public User(string name, string surname, int age, string email, string password)
        {
            id++;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.email = email;
            this.password = password;
        }

        
    }
}
