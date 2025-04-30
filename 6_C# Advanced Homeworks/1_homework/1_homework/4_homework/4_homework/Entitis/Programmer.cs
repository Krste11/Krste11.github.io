namespace _4_homework.Entitis
{
    public class Programmer : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public Programmer(string name, int id, decimal hourlyRate, int hoursWorked)
            : base(name, id)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override void CalculateSalary()
        {
            decimal totalSalary = HourlyRate * HoursWorked;
            Console.WriteLine($"Programmer {Name}'s Salary: ${totalSalary}");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Programmer Info:\nName: {Name}\nID: {ID}\nHourly Rate: ${HourlyRate}\nHours Worked: {HoursWorked}");
        }
    }
}
