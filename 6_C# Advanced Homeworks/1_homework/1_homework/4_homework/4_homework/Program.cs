using _4_homework.Entitis;

Manager manager = new Manager("Robert Panovski", 100, 5000m, 1500m);
Programmer programmer = new Programmer("Bob Bobsky", 150, 50m, 160);

Console.WriteLine("=== Manager Details ===");
manager.DisplayInfo();
manager.CalculateSalary();

Console.WriteLine("\n=== Programmer Details ===");
programmer.DisplayInfo();
programmer.CalculateSalary();