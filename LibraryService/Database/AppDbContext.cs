using LibraryService.Models;

using Microsoft.EntityFrameworkCore;

namespace LibraryService.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
