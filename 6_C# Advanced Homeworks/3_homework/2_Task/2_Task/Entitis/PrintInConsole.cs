namespace _2_Task.Entitis
{
    public static class PrintInConsole
    {
        public static void Print<T>(T item)
        {
            Console.WriteLine(item?.ToString());
        }

        public static void PrintCollection<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                Console.WriteLine("Collection is null");
                return;
            }

            foreach (T item in collection)
            {
                Print(item);
            }
        }
    }
}
