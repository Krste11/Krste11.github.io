using System.Globalization;

namespace _3_homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            int[] numbers = new int[6];
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = 0;
                Console.Write($"Please enter number {i + 1}: ");
                bool isValidNum = int.TryParse(Console.ReadLine(), out num);

                if (isValidNum)
                {
                    numbers[i] = num;
                    if (num % 2 == 0)
                    {
                        sum += num;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    i--;
                }
            }

            Console.WriteLine($"The result is: {sum}");

            #endregion

            #region Task 2
            string[] studentsG1 = new string[5] { "Zdravko", "Petko", "Stanko", "Branko", "Trajko" };
            string[] studentsG2 = new string[5] { "Bob1", "Bob2", "Bob3", "Bob4", "Bob5" };

            Console.Write("Enter a number 1 or 2: ");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int numGroup);

            if(isValidNumber)
                {
                if(numGroup == 1)
                {
                    for(int i = 0; i < studentsG1.Length; i++)
                    {
                        Console.WriteLine(studentsG1[i]);
                    }
                }
                else if(numGroup == 2)
                {
                    for (int i = 0; i < studentsG2.Length; i++)
                    {
                        Console.WriteLine(studentsG2[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number (1 or 2)");
                }
            }
            else
            {
                Console.WriteLine("Please enter a number");
            }
            #endregion

            #region Task 3
            string[] names = new string[0];
            int counter = 0;

            while (true)
            {
                Console.Write("Enter a name: ");
                string name = Console.ReadLine();

                if (counter == names.Length)
                {
                    Array.Resize(ref names, names.Length + 1);
                }

                names[counter] = name;
                counter++;

                Console.Write("Do you want to enter another name (Y/N): ");
                string yesOrNo = Console.ReadLine().ToUpper();

                if (yesOrNo == "N")
                {
                    break;
                }
            }

            Console.WriteLine("You entered these names: ");
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine(names[i]);
            }

            #endregion
        }
    }
}
