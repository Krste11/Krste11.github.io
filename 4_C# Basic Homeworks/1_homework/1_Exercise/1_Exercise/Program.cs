namespace _1_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int branches = 12;
            int applesPerBranch = 8;
            double applesPerBasket = 5;
            int totalAmoluntOfApples;
            double basketsNeedToTakeAllApples;

            int allApplesFromOneTree = branches * applesPerBranch;

            Console.Write("Enter number of trees: ");
            int numberOfTrees = int.Parse(Console.ReadLine());

            totalAmoluntOfApples = numberOfTrees * allApplesFromOneTree;

            if (totalAmoluntOfApples % applesPerBasket == 0)
            {
                basketsNeedToTakeAllApples = totalAmoluntOfApples / applesPerBasket;
                Console.WriteLine("You need " + basketsNeedToTakeAllApples + " baskets to take " + totalAmoluntOfApples + " apples");
            }
            else
            {
                basketsNeedToTakeAllApples = totalAmoluntOfApples / applesPerBasket;
                int result = Convert.ToInt32(basketsNeedToTakeAllApples) + 1;
                Console.WriteLine("You need " + result + " baskets to take " + totalAmoluntOfApples + " apples");
            }
        }
    }
}
