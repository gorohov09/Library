using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<BookEntity> Books { get; set; }
    }
}
