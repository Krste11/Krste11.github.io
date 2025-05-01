namespace _1_Task.Entities.Modals
{
    public static class UserDatabase
    {
        public static List<User> Users { get; set; } = new List<User>();
        static UserDatabase() 
        {
            Users.Add(new User(1, "Angel", 17));
            Users.Add(new User(2, "Bob", 18));
            Users.Add(new User(3, "Martin", 31));
        }
    }
}
