string appPath = @"..\..\..\";
string folderPath = Path.Combine(appPath, "Files");
string filePath = Path.Combine(folderPath, "names.txt");

List<string> names = EnteringNames();

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
    Console.WriteLine("New directory was created");
}

using (StreamWriter sw = new StreamWriter(filePath, true))
{
    foreach (string name in names)
    {
        sw.WriteLine(name);
    }
}

Console.WriteLine("Names have been saved.");

if (File.Exists(filePath))
{
    string[] allNames = File.ReadAllLines(filePath);

    for (char letter = 'A'; letter <= 'Z'; letter++)
    {
        List<string> newNames = allNames
            .Where(n => !string.IsNullOrWhiteSpace(n) && char.ToUpper(n[0]) == letter)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (newNames.Count > 0)
        {
            string newFileName = $"namesStartingWith_{letter}.txt";
            string newFilePath = Path.Combine(folderPath, newFileName);

            List<string> existingNames = new List<string>();

            if (File.Exists(newFilePath))
            {
                existingNames = File.ReadAllLines(newFilePath)
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }

            List<string> mergedNames = existingNames
                .Union(newNames, StringComparer.OrdinalIgnoreCase)
                .OrderBy(n => n, StringComparer.OrdinalIgnoreCase)
                .ToList();

            File.WriteAllLines(newFilePath, mergedNames);
            Console.WriteLine($"Updated file: {newFileName}");
        }
    }
}
else
{
    Console.WriteLine("The names.txt file does not exist.");
}
static List<string> EnteringNames()
{
    List<string> names = new List<string>();
    while (true)
    {
        Console.Write("How many users do you want to enter: ");
        string amountOfNamesString = Console.ReadLine();

        bool amountOfNamesBool = int.TryParse(amountOfNamesString, out int amountOfNames);

        if (amountOfNamesBool)
        {
            for (int i = 0; i < amountOfNames; i++)
            {
                Console.Write($"Enter name {i + 1}: ");
                string name = Console.ReadLine();

                if (IsInvalidName(name))
                {
                    Console.WriteLine("Invalid input");
                    i--;
                    continue;
                }

                names.Add(name);
            }
            return names;
        }
        else
        {
            Console.WriteLine("Invalid number. Try again.");
        }
    }
}
static bool IsInvalidName(string name)
{
    return string.IsNullOrWhiteSpace(name)
        || int.TryParse(name, out _)
        || bool.TryParse(name, out _)
        || char.TryParse(name, out _)
        || double.TryParse(name, out _);
}