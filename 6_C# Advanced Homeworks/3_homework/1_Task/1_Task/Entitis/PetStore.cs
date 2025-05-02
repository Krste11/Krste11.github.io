using System.Reflection.Emit;

namespace _1_Task.Entitis
{
    public class PetStore<T> where T : Pet
    {
        private List<T> pets = new List<T>();
        public void AddPet(T pet)
        {
            pets.Add(pet);
        }
        public void PrintPets()
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("No pets in the store");
                return;
            }

            foreach (var pet in pets)
            {
                pet.PrintInfo();
            }
        }

        public void BuyPet(string name)
        {
            for (int i = 0; i < pets.Count; i++)
            {
                if (pets[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    var pet = pets[i];
                    pets.RemoveAt(i);
                    Console.WriteLine($"You bought {pet.Name} the {pet.Type}.");
                    return;
                }
            }

            Console.WriteLine($"Sorry we do not have a pet named {name}.");
        }
    }
}
