using System.Reflection.Emit;

namespace _1_Task.Entitis
{
    public class Dog : Pet
    {
        public bool GoodBoy { get; set; }
        public string FavoriteFood { get; set; }

        public Dog(string name, int age, bool goodbye, string favoriteFood)
            : base(name, "Dog", age)
        {
            GoodBoy = goodbye;
            FavoriteFood = favoriteFood;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Dog: {Name}, Age: {Age}, GoodBoy: {GoodBoy}, Favorite food: {FavoriteFood}");
        }
    }
}
