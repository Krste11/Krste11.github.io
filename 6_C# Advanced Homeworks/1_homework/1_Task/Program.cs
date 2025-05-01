using _1_homework.Entities;
using System.Reflection.Metadata;

public class Program
{
    public static void Main(string[] args)
    {
        var doc = new _1_homework.Entities.Document("This is a simple text document containing various words.");
        var page = new _1_homework.Entities.WebPage("<html><body>Welcome to our awesome webpage!</body></html>");

        Console.WriteLine("Enter a word to search:");
        string wordToSearch = Console.ReadLine();

        bool foundInDoc = doc.Search(wordToSearch);
        Console.WriteLine(foundInDoc ? "Word found in Document." : "Word not found in Document.");

        bool foundInPage = page.Search(wordToSearch);
        Console.WriteLine(foundInPage ? "Word found in WebPage." : "Word not found in WebPage.");
    }
}