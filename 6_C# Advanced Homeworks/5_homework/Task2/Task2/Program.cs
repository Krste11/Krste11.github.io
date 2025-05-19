namespace Task2
{
    class Program
    {
        public static event Action<string> UnauthorizedAccessEvent;

        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string username = Console.ReadLine();

            HashSet<string> restrictedUsers = new HashSet<string> { "Bob", "Jill", "Alice" };

            UnauthorizedAccessEvent += SendEmailToAdmin;
            UnauthorizedAccessEvent += TriggerAlarm;
            UnauthorizedAccessEvent += Logout;

            if (restrictedUsers.Contains(username))
            {
                Console.WriteLine($"{username} Users Found.");
                UnauthorizedAccessEvent?.Invoke(username);
            }
            else
            {
                Console.WriteLine($"Welcome {username}.");
            }
        }

        static void SendEmailToAdmin(string username)
        {
            Console.WriteLine("Sending Email to Administration...");
            Console.WriteLine("Email Sent.");
        }

        static void TriggerAlarm(string username)
        {
            Console.WriteLine("Warning Alarm Started.");
        }

        static void Logout(string username)
        {
            Console.WriteLine("Logging out.");
        }
    }
}
