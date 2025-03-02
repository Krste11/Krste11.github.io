using System.Diagnostics.CodeAnalysis;

namespace _4_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter operation ( +, - , * , / ) ");
            char operation = char.Parse(Console.ReadLine());

            int result = default;

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;

            }

            Console.WriteLine("The result is " + result);
        }
    }
}
