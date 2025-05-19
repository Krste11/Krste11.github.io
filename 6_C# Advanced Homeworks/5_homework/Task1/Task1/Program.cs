using Task1.Modals;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher professorJohn = new Teacher
            {
                Name = "Martin",
                Age = 30,
                Email = "john@example.com",
                Subject = "C#"
            };

            Students alice = new Students { Name = "Alice", Age = 20, Email = "alice@example.com", Subject = "C#" };
            Students bob = new Students { Name = "Bob", Age = 21, Email = "bob@example.com", Subject = "C#" };
            Students charlie = new Students { Name = "Charlie", Age = 22, Email = "charlie@example.com", Subject = "C#" };

            professorJohn.Subscribe(alice);
            professorJohn.Subscribe(bob);
            professorJohn.Subscribe(charlie);

            professorJohn.SendNotification();

            professorJohn.Unsubscribe(alice);
            professorJohn.Unsubscribe(charlie);

            professorJohn.SendNotification();
        }
    }
}
