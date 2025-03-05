namespace _3_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number from 1 to 3: ");
            int num = int.Parse(Console.ReadLine());

            switch(num)
            {
                case 1:
                    Console.WriteLine("You got a new car");
                    break;
                case 2: 
                    Console.WriteLine("You got a new plane");
                    break;
                case 3:
                    Console.WriteLine("You got a new bike");
                    break;
                default:
                    Console.WriteLine("You enter a wrong number");
                    break;
            }
        }
    }
}
