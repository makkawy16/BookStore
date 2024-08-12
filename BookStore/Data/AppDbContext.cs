using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
               .Property(x => x.Title)
               .HasMaxLength(50);
            modelBuilder.Entity<Book>()
                .Property(x => x.Language)
                .HasMaxLength(40);
            modelBuilder.Entity<Book>()
                .Property(x => x.Description)
                .HasMaxLength(300);
            modelBuilder.Entity<Book>()
                .Property(x => x.Author)
                .HasMaxLength(20);
            modelBuilder.Entity<Book>()
                .Property(x => x.Category)
                .HasMaxLength(20);
            modelBuilder.Entity<Book>()
                .Property(x => x.BookImg)
                .IsRequired(false);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SelledBook> SelledBooks { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
    }
}
