using _1_Task.Entities.Modals;

namespace _1_Task.Entities.Services
{
    public static class UserService
    {
        public static User SearchById(int id)
        {
            for (int i = 0; i < UserDatabase.Users.Count; i++)
            {
                if (UserDatabase.Users[i].Id == id)
                {
                    return UserDatabase.Users[i];
                }
            }
            return null;
        }

        public static List<User> SearchByName(string name)
        {
            List<User> matchedUsers = new List<User>();

            for (int i = 0; i < UserDatabase.Users.Count; i++)
            {
                if (UserDatabase.Users[i].Name.ToLower().Contains(name.ToLower()))
                {
                    matchedUsers.Add(UserDatabase.Users[i]);
                }
            }

            return matchedUsers;
        }

        public static List<User> SearchByAge(int age)
        {
            List<User> matchedUsers = new List<User>();

            for (int i = 0; i < UserDatabase.Users.Count; i++)
            {
                if (UserDatabase.Users[i].Age == age)
                {
                    matchedUsers.Add(UserDatabase.Users[i]);
                }
            }

            return matchedUsers;
        }
    }
}
