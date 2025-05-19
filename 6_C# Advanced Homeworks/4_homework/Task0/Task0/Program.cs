using System.ComponentModel;
using System.Xml.Linq;

namespace Task0
{
    internal class Program
    {
        static void SortAndPrint(List<string> list, string title)
        {
            Console.WriteLine($"\n--- {title} ---");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            List<string> firstNamesStartingWithR_OrderedByAgeDesc = PeopleDB.People
                .Where(p => p.FirstName.StartsWith("R"))
                .OrderByDescending(p => p.Age)
                .Select(p => p.FirstName)
                .ToList();

            List<string> brownDogsOlderThan3_OrderedByAgeAsc = PeopleDB.People
                .SelectMany(p => p.Dogs)
                .Where(d => d.Color.ToLower() == "brown" && d.Age > 3)
                .OrderBy(d => d.Age)
                .Select(d => $"{d.Name} - {d.Age} years")
                .ToList();

            List<string> personsWithMoreThan2Dogs_OrderedByNameDesc = PeopleDB.People
                .Where(p => p.Dogs.Count > 2)
                .OrderByDescending(p => p.FirstName)
                .Select(p => p.FirstName)
                .ToList();

            List<string> freddysDogsOlderThan1 = new List<string>();
            var freddy = PeopleDB.People.FirstOrDefault(p => p.FirstName == "Freddy");
            if (freddy != null && freddy.Dogs != null)
            {
                freddysDogsOlderThan1 = freddy.Dogs
                    .Where(d => d.Age > 1)
                    .Select(d => d.Name)
                    .ToList();
            }

            List<Dog> nathensDogs = new List<Dog>();
            var nathen = PeopleDB.People.FirstOrDefault(p => p.FirstName == "Nathen");
            if (nathen != null && nathen.Dogs != null)
            {
                nathensDogs = nathen.Dogs;
            }

            string nathensFirstDog = nathensDogs.Count > 0 ? nathensDogs[0].Name : "No dog found";

            List<string> whiteDogsFromSelectedOwners_OrderedByNameAsc = PeopleDB.People
                .Where(p => new[] { "Cristofer", "Freddy", "Erin", "Amelia" }.Contains(p.FirstName))
                .SelectMany(p => p.Dogs)
                .Where(d => d.Color.ToLower() == "white")
                .OrderBy(d => d.Name)
                .Select(d => d.Name)
                .ToList();

            SortAndPrint(firstNamesStartingWithR_OrderedByAgeDesc, "First Names Starting with R (Age DESC)");
            SortAndPrint(brownDogsOlderThan3_OrderedByAgeAsc, "Brown Dogs Older Than 3 (Age ASC)");
            SortAndPrint(personsWithMoreThan2Dogs_OrderedByNameDesc, "People with More Than 2 Dogs (Name DESC)");
            SortAndPrint(freddysDogsOlderThan1, "Freddy's Dogs Older Than 1 Year");

            Console.WriteLine($"\n--- Nathen's First Dog ---\n{nathensFirstDog}");

            SortAndPrint(whiteDogsFromSelectedOwners_OrderedByNameAsc, "White Dogs from Cristofer, Freddy, Erin, Amelia (Name ASC)");
        }
    }
}
