using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> opt) : base(opt)
        {

        }

        #region DbSet
        public DbSet<Book> Books { get; set;}
        #endregion
    }
}
