public static class PeopleDB
{
    public static List<Person> People = new List<Person>()
    {
        new Person("Cristofer", "Johnson", 35, new List<Dog> {
            new Dog("Buddy", "Brown", 2),
            new Dog("Snow", "White", 4)
        }),
        new Person("Freddy", "Mercury", 40, new List<Dog> {
            new Dog("Rex", "Brown", 4),
            new Dog("Bella", "White", 2),
            new Dog("Fluffy", "Gray", 1)
        }),
        new Person("Nathen", "Peterson", 28, new List<Dog> {
            new Dog("Spike", "Black", 5),
            new Dog("Tiny", "White", 3)
        }),
        new Person("Amelia", "Thorne", 31, new List<Dog> {
            new Dog("Snowball", "White", 6)
        }),
        new Person("Erin", "Smith", 26, new List<Dog> {
            new Dog("Coco", "Brown", 1),
            new Dog("Pearl", "White", 2)
        }),
        new Person("Rachel", "Green", 29, new List<Dog> {
            new Dog("Shadow", "Black", 4)
        }),
        new Person("Robert", "Brown", 42, new List<Dog> {
            new Dog("Rover", "Brown", 5),
            new Dog("Bruno", "Brown", 6),
            new Dog("Sasha", "White", 2)
        })
    };
}
