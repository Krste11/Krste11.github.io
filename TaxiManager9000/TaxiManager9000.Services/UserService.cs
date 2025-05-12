using TaxiManager9000.Domain.Modals;

namespace TaxiManager9000.Services
{
    public class UserService
    {
        // Create a new user
        public void CreateUser(User user)
        {
            if (Program.database.Users.Any(u => u.Username == user.UserName))
            {
                throw new Exception("Username already exists.");
            }
            Program.database.Users.Add(user); // Directly accessing the public static 'database' instance
        }

        // Terminate an existing user
        public void TerminateUser(User user)
        {
            Program.database.Users.Remove(user); // Directly accessing the public static 'database' instance
        }

        // Change user's password
        public bool ChangePassword(User user, string newPassword)
        {
            var existingUser = Program.database.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
            {
                existingUser.Password = newPassword;
                return true;
            }
            return false;
        }

        // Login validation
        public User Login(string username, string password)
        {
            return Program.database.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
