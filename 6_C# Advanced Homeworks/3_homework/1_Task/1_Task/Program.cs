using _1_Task.Entitis;

PetStore<Dog> dogStore = new PetStore<Dog>();
dogStore.AddPet(new Dog("Bob", 2, true, "Bone"));
dogStore.AddPet(new Dog("Bobi", 1, false, "Bone"));

PetStore<Cat> catStore = new PetStore<Cat>();
catStore.AddPet(new Cat("Maca", 6, true, 5));
catStore.AddPet(new Cat("Mica", 5, false, 6));

PetStore<Fish> fishStore = new PetStore<Fish>();
fishStore.AddPet(new Fish("Jon", 1, "Orange", "Small"));
fishStore.AddPet(new Fish("Joni", 2, "Blue", "Big"));

dogStore.BuyPet("Bob");

catStore.BuyPet("Mica");

fishStore.BuyPet("Joni");

Console.WriteLine("\nDog Store Pets:");
dogStore.PrintPets();

Console.WriteLine("\nCat Store Pets:");
catStore.PrintPets();

Console.WriteLine("\nFish Store Pets:");
fishStore.PrintPets();