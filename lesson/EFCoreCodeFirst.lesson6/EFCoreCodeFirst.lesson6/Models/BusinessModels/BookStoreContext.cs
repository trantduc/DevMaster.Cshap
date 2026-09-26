using EFCoreCodeFirst.lesson6.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.lesson6.Models.BusinessModels
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
