namespace _6._2_homework.Library
{
    public class CEO : Employee
    {
        public double SharesPrice { get; private set; }

        public CEO(string name, double salary, Employee[] employees, int shares)
            : base(name, "CEO", salary)
        {
            Employees = employees;
            Shares = shares;
        }

        public Employee[] Employees { get; set; }
        public int Shares { get; set; }

        public void AddSharesPrice(double amount)
        {
            SharesPrice = amount;
        }

        public void PrintEmployees()
        {
            Console.WriteLine("Employees:");
            foreach (Employee employee in Employees)
            {
                employee.GetSalary();
                employee.PrintInfo();
                if (employee is Contractor contractor)
                {
                    Console.WriteLine($"Responsible Manager's Department: {contractor.CurrentPosition()}");
                }
            }
        }

        public override double GetSalary()
        {
            return Salary + Shares * SharesPrice;
        }

        public new void PrintInfo()
        {
            string[] fullName = Name.Split(' ');
            string firstName = fullName[0];
            string lastName;

            if (fullName.Length > 1)
            {
                lastName = fullName[1];
            }
            else
            {
                lastName = "";
            }
            Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Salary: {Salary}");
        }
    }
}
