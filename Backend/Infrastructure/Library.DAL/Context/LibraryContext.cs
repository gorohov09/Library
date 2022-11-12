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

        public DbSet<BookEntity> BookInfos { get; set; }
        public DbSet<BookInsatnceEntity> BookIntances { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BooksAuthorsEntity> BooksAuthors { get; set; }
        public DbSet<ReaderEntity> Readers { get; set; }
        public DbSet<LibrarianEntity> Librarians { get; set; }
        public DbSet<RecordEntity> Records { get; set; }


    }
}
