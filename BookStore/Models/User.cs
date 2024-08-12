using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class User
    {

        public int Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        public int UserType { get; set; }

    }
}
