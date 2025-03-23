namespace _6._2_homework.Library
{
    public class Manager : Employee
    {
        public Manager(string name, string position, double salary, string department)
            : base(name, position, salary)
        {
            Department = department;
        }

        public string Department { get; set; }
    }
}
