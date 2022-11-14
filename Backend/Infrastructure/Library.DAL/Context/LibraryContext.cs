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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BooksAuthorsEntity>().HasKey(u => new { u.AuthorID, u.ISBN });

            //Настройка связи многие-ко-многим между авторами и книгами
            modelBuilder
            .Entity<BookEntity>()
            .HasMany(c => c.Authors)
            .WithMany(s => s.Books)
            .UsingEntity<BooksAuthorsEntity>(
               j => j
                .HasOne(pt => pt.Author)
                .WithMany(t => t.BooksAuthors)
                .HasForeignKey(pt => pt.AuthorID),
            j => j
                .HasOne(pt => pt.Book)
                .WithMany(p => p.BooksAuthors)
                .HasForeignKey(pt => pt.ISBN),
            j =>
            {
                j.HasKey(t => new { t.AuthorID, t.ISBN });
                j.ToTable("AuthorBook");
            });

            modelBuilder.Entity<ReaderEntity>().HasCheckConstraint("BirthYear", "BirthYear LIKE '[1-2][0,8-9][0-9][0-9]'");
            modelBuilder.Entity<BookEntity>().HasCheckConstraint("Year", "Year LIKE '[1-2][0-9][0-9][0-9]'");

            modelBuilder.Entity<LibrarianEntity>().HasCheckConstraint("MobilePhone", "MobilePhone LIKE '[8][9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
            modelBuilder.Entity<ReaderEntity>().HasCheckConstraint("MobilePhone", "MobilePhone LIKE '[8][9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");

            modelBuilder.Entity<ReaderEntity>().HasCheckConstraint("LibraryCard", "LibraryCard LIKE '[1-9][0-9][0-9][0-9][0-9][0-9]'");
            modelBuilder.Entity<ReaderEntity>().HasCheckConstraint("StudentCard", "StudentCard LIKE '[1-9][0-9][0-9][0-9][0-9][0-9]'");
        }


    }
}
