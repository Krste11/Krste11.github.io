namespace Task1.Modals
{
    public class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }

        public event Action<string> NotifyStudents;

        public void Subscribe(Students student)
        {
            NotifyStudents += student.GetNotification;
            Console.WriteLine($"{student.Name} subscribed to Professor {Name}'s notifications.");
        }

        public void Unsubscribe(Students student)
        {
            NotifyStudents -= student.GetNotification;
            Console.WriteLine($"{student.Name} unsubscribed from Professor {Name}'s notifications.");
        }

        public void SendNotification()
        {
            Console.WriteLine("Sending notifications....");
            NotifyStudents?.Invoke($"Notification from Professor {Name}: Class for {Subject} will start at 10 AM.");
        }
    }
}
