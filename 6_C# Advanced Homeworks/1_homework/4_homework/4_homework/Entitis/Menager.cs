namespace _4_homework.Entitis
{
    public class Manager : Employee
    {
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }

        public Manager(string name, int id, decimal baseSalary, decimal bonus)
            : base(name, id)
        {
            BaseSalary = baseSalary;
            Bonus = bonus;
        }

        public override void CalculateSalary()
        {
            decimal totalSalary = BaseSalary + Bonus;
            Console.WriteLine($"Manager {Name}'s Salary: ${totalSalary}");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Manager Info:\nName: {Name}\nID: {ID}\nBase Salary: ${BaseSalary}\nBonus: ${Bonus}");
        }
    }
}
