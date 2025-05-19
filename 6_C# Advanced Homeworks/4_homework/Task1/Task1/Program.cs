namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            List<Car> europeanCars = CarsData.Cars
                .Where(c => c.Origin == "Europe")
                .ToList();

            foreach (var car in europeanCars)
            {
                Console.WriteLine($"{car.Model} - {car.Origin}");
            }
            Console.WriteLine();

            List<Car> moreThan6Cylinders = CarsData.Cars
                .Where(c => c.Cylinders > 6)
                .ToList();
            List<Car> fourCylindersHighHP = CarsData.Cars
                .Where(c => c.Cylinders == 4 && c.HorsePower > 110)
                .ToList();
            List<Car> combinedResult = moreThan6Cylinders
                .Concat(fourCylindersHighHP)
                .ToList();

            foreach (var car in combinedResult)
            {
                Console.WriteLine($"{car.Model} - Cylinders: {car.Cylinders}, HP: {car.HorsePower}");
            }
            Console.WriteLine();

            var carsByOrigin = CarsData.Cars
                .GroupBy(c => c.Origin)
                .Select(g => (Origin: g.Key, Count: g.Count()))
                .ToList();

            foreach (var item in carsByOrigin)
            {
                Console.WriteLine($"{item.Origin} {item.Count} models");
            }
            Console.WriteLine();

            List<Car> highHPCars = CarsData.Cars
                .Where(c => c.HorsePower > 200)
                .ToList();

            if (highHPCars.Any())
            {
                double minMPG = highHPCars
                    .Min(c => c.MilesPerGalon);
                double maxMPG = highHPCars
                    .Max(c => c.MilesPerGalon);
                double avgMPG = highHPCars
                    .Average(c => c.MilesPerGalon);
                Console.WriteLine($"Min MPG: {minMPG}, Max MPG: {maxMPG}, Avg MPG: {avgMPG:F2}");
            }
            else
            {
                Console.WriteLine("No cars found");
            }
            Console.WriteLine();

            List<Car> fastestCars = CarsData.Cars
                .OrderBy(c => c.AccelerationTime)
                .Take(3)
                .ToList();
            foreach (var car in fastestCars)
            {
                Console.WriteLine($"{car.Model} - {car.AccelerationTime} seconds");
            }
            Console.WriteLine();

            double totalWeight = CarsData.Cars
                .Where(c => c.Cylinders > 6)
                .Sum(c => c.Weight);
            Console.WriteLine($"{totalWeight} lbs");
            Console.WriteLine();

            double avgMPGEvenCylinders = CarsData.Cars
                .Where(c => c.Cylinders % 2 == 0)
                .Average(c => c.MilesPerGalon);
            Console.WriteLine($"{avgMPGEvenCylinders:F2}");
        }
    }
}
