namespace _6._2_homework.Library
{
    public class Contractor : Employee
    {
        public Contractor(string name, double workHours, int payPerHour, Manager responsible)
            : base(name, "Contractor", 0)
        {
            WorkHours = workHours;
            PayPerHour = payPerHour;
            Responsible = responsible;
        }

        public double WorkHours { get; set; }
        public int PayPerHour { get; set; }
        public Manager Responsible { get; set; }

        public override double GetSalary()
        {
            Salary = WorkHours * PayPerHour;
            return Salary;
        }

        public string CurrentPosition()
        {
            return Responsible.Department;
        }
    }
}
