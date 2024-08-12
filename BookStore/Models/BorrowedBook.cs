namespace BookStore.Models
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string BookTitile { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Price { get; set; }
    }
}
