namespace Task1.Modals
{
    public class Students
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }

        public void GetNotification(string text)
        {
            Console.WriteLine($"Student {Name} is saying {text}");
        }
    }
}
