namespace LenusHealthTechTest
{
    using LenusHealthTechTest.Entities.Core;
    using Microsoft.EntityFrameworkCore;

    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : 
            base(options) 
        { }

        public DbSet<Book> Books { get; set; }

    }
}
