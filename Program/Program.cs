using Program;
namespace App
{
    public class Notifications
    {
        public List<Notification> Nots = new();

        public List<Notification> GetNots() => Nots;

        public void AddNot(string text,User user)
        {
            Nots.Add(new Notification(text,user));
        }
    }
    public class Full
    {
        private List<Admin> admins = new();
        private List<User> users = new();
        private List<Post> posts = new();

        public List<Admin> GetAdmins() => admins;
        public List<Post> GetPosts() => posts;
        public List<User> GetUsers() => users;
        public void SetAdmin(Admin admin)
        {
            admins.Add(admin);
        }
        public void SetPost(Post post)
        {
            posts.Add(post);
        }
        public void SetUsers(User user)
        {
            users.Add(user);
        }
    }
    class Process
    {

        public static void LogInAdmin(ref Full full,ref Notifications nots)
        {
        login:
            Console.Clear();
            bool AdminAccess = false;
            Console.WriteLine($"Only enter to back\n\t\tUsername or email : ");
            string? username = Console.ReadLine();
            Console.WriteLine($"\t\tPassword : ");
            string? password = Console.ReadLine();
            if (username == "" && password == "")
            {
                Console.Clear();
                Choice(ref full, ref nots);
            }
            foreach (var admin in full.GetAdmins())
            {
                if ((admin.username == username || admin.email == username) && admin.password == password)
                {
                    logined:
                    Console.Clear();
                    Console.WriteLine($"Hello {admin.username}");
                    AdminAccess = true;
                    for (int i = 0; i < nots.Nots.Count; i++)
                    {
                        Console.WriteLine(nots.GetNots()[i].User.name + " "+ nots.GetNots()[i].Text + $"   " + nots.GetNots()[i].dateTime) ;
                    }
                    Console.WriteLine($"1) Posts\n2) Add user\n3) Back");
                    Console.WriteLine($"Enter choice : ");
                    int ch = Console.ReadKey().KeyChar;
                    if(ch == '3') { goto login; }
                    else if (ch == '2')
                    {
                        Console.Clear();
                        Console.WriteLine("Name : \n\t\t\t");
                        string? newName = Console.ReadLine();
                        Console.WriteLine("Surname : \n\t\t\t");
                        string? newUsername = Console.ReadLine();
                        Console.WriteLine("Age : \n\t\t\t");
                        int newAge = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Email : \n\t\t\t");
                        string? newEmail = Console.ReadLine();
                        Console.WriteLine("Password : \n\t\t\t");
                        string? newPassword = Console.ReadLine();
                        if (newName != null && newUsername != null && newAge != 0 && newEmail != null && newPassword != null && newAge > 18)
                        {
                            full.SetUsers(new(newName, newUsername, newAge, newEmail, newPassword));
                            Console.WriteLine("\n\t\t\t\t\t\tUser added!");
                            Console.Read();
                        }
                        else { 
                            Console.WriteLine("User doesn't added!");
                            Console.Read();
                            goto logined;
                        }
                    }
                    else if(ch == '1')
                    {
                        for (int i = 0; i < full.GetPosts().Count ;)
                        {
                            Console.Clear();
                            full.GetPosts()[i].ViewCount++;
                            Console.WriteLine("W => delete");
                            Console.WriteLine("D => next");
                            Console.WriteLine("A => back");
                            Console.WriteLine("S => exit");
                            Console.WriteLine("\t\t\t");
                            Console.WriteLine(full.GetPosts()[i].ID + 1 + ")");
                            Console.WriteLine(full.GetPosts()[i].Content + "\n*************************************************************");
                            Console.WriteLine(full.GetPosts()[i].DateTime + "\t\t\t" + full.GetPosts()[i].Like + "\t\t" + full.GetPosts()[i].ViewCount);
                            char key = Console.ReadKey().KeyChar;
                            if (key == 'd')
                            {
                                if (i < full.GetPosts().Count - 1)
                                    i++;
                                else if (i == full.GetPosts().Count - 1)
                                    i = 0;
                            }
                            else if (key == 'a')
                            {
                                if (i > 0)
                                    i--;
                                else if (i == 0)
                                    i = full.GetPosts().Count - 1;
                            }
                            else if (key == 'w')
                            {
                                full.GetPosts().RemoveAt(i);
                            }
                            else if (key == 's')
                            {
                                Choice(ref full, ref nots);
                            }
                            else
                                continue;

                        }
                    }
                    break;
                    
                }
            }

            if (!AdminAccess)
            {
                Console.WriteLine("Username or password is wrong!");
                Console.Read();
                LogInAdmin(ref full, ref nots);
            }
        }
        public static void LogInUser(ref Full full, ref Notifications nots)
        {
            Console.Clear();
            bool UserAccess = false;
            Console.WriteLine($"Only enter to back\n\t\tUsername or email : ");
            string? username = Console.ReadLine();
            Console.WriteLine($"\t\tPassword : ");
            string? password = Console.ReadLine();
            if (username == "" && password == "")
            {
                Choice(ref full, ref nots);
            }
            foreach (var user in full.GetUsers())
            {
                if (user.email == username && user.password == password)
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {user.email}");
                    UserAccess = true;
                    for (int i = 0; i < full.GetPosts().Count;)
                    {
                    to:
                        Console.Clear();
                        full.GetPosts()[i].ViewCount++;
                        Console.WriteLine("W => like" );
                        Console.WriteLine("D => next" );
                        Console.WriteLine("A => back" );
                        Console.WriteLine("S => exit" );
                        Console.WriteLine("\t\t\t" );
                        Console.WriteLine(full.GetPosts()[i].ID + 1 + ")");
                        Console.WriteLine(full.GetPosts()[i].Content + "\n*************************************************************");
                        Console.WriteLine(full.GetPosts()[i].DateTime + "\t\t\t" + full.GetPosts()[i].Like + "\t\t" + full.GetPosts()[i].ViewCount);
                        char key = Console.ReadKey().KeyChar;
                        if (key == 'd')
                        {
                            if (i < full.GetPosts().Count - 1)
                                i++;
                            else if (i == full.GetPosts().Count - 1)
                                i = 0;
                        }
                        else if (key == 'a')
                        {
                            if(i > 0)
                                i--;
                            else if(i == 0)
                                i = full.GetPosts().Count - 1;
                        }
                        else if (key == 'w')
                        {
                            full.GetPosts()[i].Like++;
                            nots.AddNot("liked your photo",user);
                            full.GetPosts()[i].ViewCount--;
                        }
                        else if (key == 's')
                        {
                            Choice(ref full, ref nots);
                        }
                        else
                            goto to;

                    }
                }
            }
            if (!UserAccess)
            {
                Console.WriteLine("Username or password is wrong!");
                Console.Read();
            }
            LogInUser(ref full, ref nots);
        }
        static int ID = 0;

        public static void Choice(ref Full full,ref Notifications nots)
        {
            Console.Clear(); 
            Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\tWelcome!");
            Console.WriteLine("1 - Admin\n2 - User\n");
            int choise = Console.ReadKey().KeyChar;
            if (choise == '1')
            {
                LogInAdmin(ref full, ref nots);
            }
            if (choise == '2')
            {
                LogInUser(ref full, ref nots);
            }
        }
        public static void Start()
        {
            Notifications nots = new();
            Full full = new();
            full.SetAdmin(new Admin("Cavad994", "yusifzadecavad@gmail.com", "cavad994"));
            full.SetUsers(new User("Fazil", "Fazilov", 20, "fazo@mail.ru", "fazil123"));
            full.SetPost(new Post(ID++, "Hamiya salam"));
            full.SetPost(new Post(ID++, "Qulle vuruldu"));
            full.SetPost(new Post(ID++, "Hey guys, we have a gift for you!"));

            Choice(ref full,ref nots);
        }
    }

    class MyMain
    {
        Process Process;
        static void Main(string[] args)
        {
            Process.Start();
        }
    }
}
