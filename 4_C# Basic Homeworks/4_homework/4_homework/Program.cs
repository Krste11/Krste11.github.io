using _4_homework.Modals;

namespace _4_homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueRacing = true;

            while (continueRacing)
            {
                Driver driver1 = new Driver("Bob1", 8);
                Driver driver2 = new Driver("Bob2", 7);
                Driver driver3 = new Driver("Bob3", 9);
                Driver driver4 = new Driver("Bob4", 6);

                Car car1 = new Car("Hyundai", 180);
                Car car2 = new Car("Mazda", 150);
                Car car3 = new Car("Ferrari", 220);
                Car car4 = new Car("Porsche", 230);

                bool[] carSelected = new bool[4];
                bool[] driverSelected = new bool[4];

                Console.WriteLine("Select a car for Driver 1 (1-4):");
                Car selectedCar1 = SelectCar(new[] { car1, car2, car3, car4 }, carSelected);

                Console.WriteLine("Select a driver for Car 1 (1-4):");
                selectedCar1.Driver = SelectDriver(new[] { driver1, driver2, driver3, driver4 }, driverSelected);

                Console.WriteLine("Select a car for Driver 2 (1-4):");
                Car selectedCar2 = SelectCar(new[] { car1, car2, car3, car4 }, carSelected);

                Console.WriteLine("Select a driver for Car 2 (1-4):");
                selectedCar2.Driver = SelectDriver(new[] { driver1, driver2, driver3, driver4 }, driverSelected);

                RaceCars(selectedCar1, selectedCar2);

                Console.WriteLine("Do you want to race again? (yes/no)");
                string response = Console.ReadLine().Trim().ToLower();
                continueRacing = response == "yes";
            }
        }

        static Car SelectCar(Car[] cars, bool[] carSelected)
        {
            int choice;
            while (true)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    if (!carSelected[i])
                    {
                        Console.WriteLine($"{i + 1}. {cars[i].Model} (Speed: {cars[i].Speed})");
                    }
                }

                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= cars.Length && !carSelected[choice - 1])
                {
                    carSelected[choice - 1] = true;
                    return cars[choice - 1];
                }

                Console.WriteLine("Invalid choice or car already selected. Try again.");
            }
        }

        static Driver SelectDriver(Driver[] drivers, bool[] driverSelected)
        {
            int choice;
            while (true)
            {
                for (int i = 0; i < drivers.Length; i++)
                {
                    if (!driverSelected[i])
                    {
                        Console.WriteLine($"{i + 1}. {drivers[i].Name} (Skill: {drivers[i].Skill})");
                    }
                }

                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= drivers.Length && !driverSelected[choice - 1])
                {
                    driverSelected[choice - 1] = true;
                    return drivers[choice - 1];
                }

                Console.WriteLine("Invalid choice or driver already selected. Try again.");
            }
        }

        static void RaceCars(Car car1, Car car2)
        {
            double speed1 = car1.CalculateSpeed(car1.Driver.Skill, car1.Speed);
            double speed2 = car2.CalculateSpeed(car2.Driver.Skill, car2.Speed);

            Console.WriteLine($"\n=== Race Results ===");
            Console.WriteLine($"{car1.Driver.Name} driving {car1.Model} has a total speed of {speed1}");
            Console.WriteLine($"{car2.Driver.Name} driving {car2.Model} has a total speed of {speed2}");

            if (speed1 > speed2)
            {
                Console.WriteLine($"The winner is {car1.Driver.Name} driving {car1.Model} with a speed of {speed1}!");
            }
            else if (speed2 > speed1)
            {
                Console.WriteLine($"The winner is {car2.Driver.Name} driving {car2.Model} with a speed of {speed2}!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }
}
