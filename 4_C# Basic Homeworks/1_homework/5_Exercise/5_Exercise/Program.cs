namespace _5_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter number: ");
            int num3 = int.Parse(Console.ReadLine());

            Console.Write("Enter number: ");
            int num4 = int.Parse(Console.ReadLine());

            int averageNumberSum = default;

            averageNumberSum = num1 + num2 + num3 + num4;
            int averageNumber = averageNumberSum / 4;
            Console.WriteLine("The average number is " + averageNumber);
        }
    }
}
