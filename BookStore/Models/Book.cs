namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int PriceForBorrow { get; set; }
        public int PriceForSale { get; set; }
        public string BookImg { get; set; }
    }
}
