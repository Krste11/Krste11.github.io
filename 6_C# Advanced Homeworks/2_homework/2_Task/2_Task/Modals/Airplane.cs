namespace _2_Task.Modals
{
    public class Airplane : Vehicle
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Im a plane and i have a couple of wheels :)");
        }
        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }
}
