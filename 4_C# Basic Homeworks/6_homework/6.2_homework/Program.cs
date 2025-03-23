using _6._2_homework.Library;
using System.Diagnostics.Contracts;

namespace _6._2_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] company = new Employee[]
            {
                new Contractor("Bob Bobert", 100, 20, new Manager("Mona Monalisa", "Manager", 4000, "Sales")),
                new Contractor("Rick Rickert", 120, 25, new Manager("Igor Igorsky", "Manager", 4100, "IT")),
                new Manager("Mona Monalisa", "Manager", 4000, "Sales"),
                new Manager("Igor Igorsky", "Manager", 4100, "IT"),
                new Employee("Lea Leova", "SalesPerson", 3000)
            };

            CEO ceo = new CEO("Ron Ronsky", 1500, company, 20);

            ceo.AddSharesPrice(70);

            ceo.PrintInfo();
            ceo.PrintEmployees();
            Console.WriteLine($"Salary of CEO is: {ceo.GetSalary()}");
        }
    }
}
