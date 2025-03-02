namespace _2_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number ");
            int num2 = int.Parse(Console.ReadLine());

            int largerNumber = default;

            if(num1 > num2)
            {
                largerNumber = num1;
                Console.WriteLine(num1 + " is larger");
            }
            else if(num2 > num1)
            {
                largerNumber = num2;
                Console.WriteLine(num2 + " is larger");
            }
            else
            {
                largerNumber = num1;
                Console.WriteLine("They are equal");
            }

            if(largerNumber == 0)
            {
                Console.WriteLine("The number is 0");
            }
            else if(largerNumber % 2 == 0)
            {
                Console.WriteLine("Number " + largerNumber + " is odd");
            }
            else
            {
                Console.WriteLine("Number " + largerNumber + " is even");
            }
        }
    }
}
