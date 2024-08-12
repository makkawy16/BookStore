using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class SelledBook
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string BookTitle { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
