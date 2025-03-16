using System.Globalization;

namespace _4_homework.Modals
{
    public class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver Driver { get; set; }

        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public double CalculateSpeed(int driverSkill, int speed)
        {
            return driverSkill * speed;
        }
    }
}
