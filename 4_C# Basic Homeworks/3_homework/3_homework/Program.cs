using System.Diagnostics.Contracts;
using System.Text.Json.Serialization.Metadata;

namespace _3_homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int years = default;
            int mounth = default; 
            int days = default;

            while (true)
            {
                // ~~~~~~~~~~~~~~~~~~~~ Years ~~~~~~~~~~~~~~~~~~~~
                Console.Write("Enter your birth year: ");
                bool yearsBool = int.TryParse(Console.ReadLine(), out years);

                if (!yearsBool || years > DateTime.Now.Year)
                {
                    Console.WriteLine("Please enter a valid year.");
                    continue;
                }
                
                // ~~~~~~~~~~~~~~~~~~~~ Mounth ~~~~~~~~~~~~~~~~~~~~
                Console.Write("Enter your birth mounth: ");
                bool mounthBool = int.TryParse(Console.ReadLine(), out mounth);

                if (!mounthBool || mounth < 1 || mounth > 12)
                {
                    Console.WriteLine("Please enter a valid mounth.");
                    continue;
                }

                // ~~~~~~~~~~~~~~~~~~~~ Days ~~~~~~~~~~~~~~~~~~~~
                Console.Write("Enter your birth day: ");
                bool daysBool = int.TryParse(Console.ReadLine(), out days);

                if (!daysBool || days < 1 || days > 31)
                {
                    Console.WriteLine("Please enter a valid day.");
                    continue;
                }

                break;
            }

            int age = AgeCalculator(years, mounth, days);
            Console.WriteLine($"You are {age} years old.");
        }

        static int AgeCalculator(int years, int mounth, int days)
        {
            int age = DateTime.Now.Year - years;

            if (DateTime.Now.Month < mounth)
            {
                age--;
            }
            else if (DateTime.Now.Month == mounth)
            {
                if (DateTime.Now.Day < days)
                {
                    age--;
                }
            }

            return age;
        }
    }
}
