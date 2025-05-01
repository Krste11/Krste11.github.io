using _1_homework.Interfaces;

namespace _1_homework.Entities
{
    public class Document : Searchable
    {
        private string Content;

        public Document(string content)
        {
            Content = content;
        }

        public bool Search(string word)
        {
            Console.WriteLine("Searching in Document...");
            return Content.Contains(word);
        }
    }
}
