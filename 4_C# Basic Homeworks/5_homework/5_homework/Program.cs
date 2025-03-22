using _13.Modals;
using System.ComponentModel.Design;

namespace _13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM app");

            CreditCard user1 = new CreditCard("Angel", "Krstevski", "1234123412341234", "1234", 2000);
            CreditCard user2 = new CreditCard("Bob", "Bobsky", "4321432143214321", "4321", 1500);

            CreditCard[] users = new CreditCard[2] { user1, user2 };

            string creditCardNumber = "";
            string creditCardPin = "";

            bool isValidCardNumber = false;
            while (!isValidCardNumber)
            {
                Console.WriteLine("Please enter your card number:");
                creditCardNumber = Console.ReadLine();
                isValidCardNumber = ValidateCreditCardNumber(creditCardNumber);
            }

            bool isValidPin = false;
            while (!isValidPin)
            {
                Console.WriteLine("Please enter your pin:");
                creditCardPin = Console.ReadLine();
                isValidPin = ValidateCreditCardPin(creditCardPin);
            }

            if (isValidCardNumber && isValidPin)
            {
                bool userFound = false;
                for (int i = 0; i < users.Length; i++)
                {
                    if (creditCardNumber == users[i].CreditCardNumber)
                    {
                        Console.WriteLine($"Welcome {users[i].FirstName} {users[i].LastName}");
                        userFound = true;
                        Console.WriteLine("What do you want to do? \n1. Balance checking \n2. Cash withdrawal \n3. Cash deposition");

                        bool choiseBool = false;
                        int choise = default;

                        while (!choiseBool)
                        {
                            choiseBool = int.TryParse(Console.ReadLine(), out choise) && choise >= 1 && choise <= 3;

                            if (!choiseBool)
                            {
                                Console.WriteLine("Please enter a valid number from 1 to 3.");
                            }
                            else
                            {
                                switch (choise)
                                {
                                    case 1:
                                        Console.WriteLine($"{users[i].FirstName} {users[i].LastName}'s balance is {users[i].Balance}$");
                                        Console.WriteLine("Thank you for using the ATM app");
                                        break;
                                    case 2:
                                        Withdrawal(users[i].Balance);
                                        break;
                                    case 3:
                                        Deposition(users[i].Balance);
                                        break;
                                }
                            }
                        }

                        break;
                    }
                }

                if (!userFound)
                {
                    Console.WriteLine("Invalid card number or pin");
                }
            }
            else
            {
                Console.WriteLine("Invalid card number or pin");
            }
        }

        static bool ValidateCreditCardNumber(string number)
        {
            bool isValid = long.TryParse(number, out long numberNum);
            if (!isValid || number.Length != 16)
            {
                Console.WriteLine("Invalid card number. Please try again (must be 16 digits).");
                return false;
            }
            return true;
        }

        static bool ValidateCreditCardPin(string pin)
        {
            bool isValid = int.TryParse(pin, out int numberNum);
            if (!isValid || pin.Length != 4)
            {
                Console.WriteLine("Invalid PIN. Please try again (must be 4 digits).");
                return false;
            }
            return true;
        }

        static void Withdrawal(double balance)
        {
            while (true)
            {
                Console.WriteLine("How much many do you want to take: ");
                bool withdrawalBool = int.TryParse(Console.ReadLine(), out int withdrawal);

                if (!withdrawalBool)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                else if (balance < withdrawal)
                {
                    Console.WriteLine($"You only have {balance}$");
                    continue;
                }
                else
                {
                    Console.WriteLine($"You take {withdrawal}$");
                    Console.WriteLine($"You have left {balance - withdrawal}$");
                    Console.WriteLine("Thank you for using the ATM app");
                    break;
                }
            }
        }

        static double Deposition(double balance)
        {
            Console.WriteLine("How much money do you want to deposit: ");
            bool depositBool = int.TryParse(Console.ReadLine(), out int deposit);

            if (!depositBool || deposit <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
                return balance;
            }

            balance += deposit;
            Console.WriteLine($"You deposited {deposit}$");
            Console.WriteLine($"Your new balance is {balance}$");
            Console.WriteLine("Thank you for using the ATM app");
            return balance;
        }
    }
}
