namespace ShoesApp.Models
{
    public class Shoe
    {
        public int Id { get; set; } 
        public string Brand { get; set; }  // Nike, Adidas, etc.
        public string Model { get; set; }  // Air Max, Ultraboost, etc.
        public string Category { get; set; }  // Running, Casual, Formal, etc.
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string ImageUrl { get; set; }
    }
}
