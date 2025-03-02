namespace _6_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 5;
            int num2 = 8;
            int swap = default;

            Console.WriteLine("Num1 before " + num1);
            Console.WriteLine("Num2 before " + num2);

            swap = num1;
            num1 = num2;
            num2 = swap;

            Console.WriteLine("Num1 after " + num1);
            Console.WriteLine("Num2 after " + num2);
        }
    }
}
