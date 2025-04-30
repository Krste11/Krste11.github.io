namespace _1_homework.Entities
{
    public class WebPage
    {
        private string HtmlContent;

        public WebPage(string htmlContent)
        {
            HtmlContent = htmlContent;
        }

        public bool Search(string word)
        {
            Console.WriteLine("Searching in WebPage...");
            return HtmlContent.Contains(word);
        }
    }
}
