using _2_homework.Entitys;
using _2_homework.Interfaces;

Shape rectangle = new Rectangle(5, 15);
Shape circle = new Circle(10);
Shape triangle = new Triangle(2, 5);

Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}");
Console.WriteLine($"Circle Area: {circle.GetArea()}");
Console.WriteLine($"Triangle Area: {triangle.GetArea()}");