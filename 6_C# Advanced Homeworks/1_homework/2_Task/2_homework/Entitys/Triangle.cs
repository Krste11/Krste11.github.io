using _2_homework.Interfaces;

namespace _2_homework.Entitys
{
    class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public double GetArea()
        {
            return 0.5 * BaseLength * Height;
        }
    }
}
