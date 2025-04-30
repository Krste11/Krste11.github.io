using _3_homework.Entities;

Circle circle = new Circle(5.0);
Console.WriteLine("Circle:");
Console.WriteLine($"Area: {circle.CalculateArea():F2}");
Console.WriteLine($"Perimeter: {circle.CalculatePerimeter():F2}");

Console.WriteLine();

Triangle triangle = new Triangle(3.0, 4.0, 5.0);
Console.WriteLine("Triangle:");
Console.WriteLine($"Area: {triangle.CalculateArea():F2}");
Console.WriteLine($"Perimeter: {triangle.CalculatePerimeter():F2}");