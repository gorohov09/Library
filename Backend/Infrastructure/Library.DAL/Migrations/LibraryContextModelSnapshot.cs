﻿// <auto-generated />
using System;
using Library.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.DAL.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorEntityBookEntity", b =>
                {
                    b.Property<string>("AuthorsISBN")
                        .HasColumnType("char(13)");

                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsISBN", "AuthorsId");

                    b.HasIndex("AuthorsId");

                    b.ToTable("AuthorEntityBookEntity");
                });

            modelBuilder.Entity("Library.Domain.Entities.AuthorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Library.Domain.Entities.BookEntity", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("char(13)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("char(4)");

                    b.HasKey("ISBN");

                    b.ToTable("Book");

                    b.HasCheckConstraint("Year", "Year LIKE '[1-2][0-9][0-9][0-9]'");
                });

            modelBuilder.Entity("Library.Domain.Entities.BookInsatnceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("char(13)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ISBN");

                    b.ToTable("BookInstance");
                });

            modelBuilder.Entity("Library.Domain.Entities.BooksAuthorsEntity", b =>
                {
                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("char(13)");

                    b.HasKey("AuthorID", "ISBN");

                    b.HasIndex("ISBN");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("Library.Domain.Entities.LibrarianEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.HasKey("Id");

                    b.ToTable("Librarian");

                    b.HasCheckConstraint("MobilePhone", "MobilePhone LIKE '[8][9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
                });

            modelBuilder.Entity("Library.Domain.Entities.ReaderEntity", b =>
                {
                    b.Property<string>("LibraryCard")
                        .HasColumnType("char(6)");

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasColumnType("char(4)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHasDebt")
                        .HasColumnType("bit");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<string>("StudentCard")
                        .IsRequired()
                        .HasColumnType("char(6)");

                    b.HasKey("LibraryCard");

                    b.ToTable("Reader");

                    b.HasCheckConstraint("BirthYear", "BirthYear LIKE '[1-2][0,8-9][0-9][0-9]'");

                    b.HasCheckConstraint("LibraryCard", "LibraryCard LIKE '[1-9][0-9][0-9][0-9][0-9][0-9]'");

                    b.HasCheckConstraint("MobilePhone", "MobilePhone LIKE '[8][9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");

                    b.HasCheckConstraint("StudentCard", "StudentCard LIKE '[1-9][0-9][0-9][0-9][0-9][0-9]'");
                });

            modelBuilder.Entity("Library.Domain.Entities.RecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibrarianID")
                        .HasColumnType("int");

                    b.Property<string>("ReaderID")
                        .IsRequired()
                        .HasColumnType("char(6)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LibrarianID");

                    b.HasIndex("ReaderID");

                    b.ToTable("History");
                });

            modelBuilder.Entity("AuthorEntityBookEntity", b =>
                {
                    b.HasOne("Library.Domain.Entities.BookEntity", null)
                        .WithMany()
                        .HasForeignKey("AuthorsISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.AuthorEntity", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Domain.Entities.BookInsatnceEntity", b =>
                {
                    b.HasOne("Library.Domain.Entities.BookEntity", "BookInfo")
                        .WithMany()
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookInfo");
                });

            modelBuilder.Entity("Library.Domain.Entities.BooksAuthorsEntity", b =>
                {
                    b.HasOne("Library.Domain.Entities.AuthorEntity", "Author")
                        .WithMany("BooksAuthors")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.BookEntity", "Book")
                        .WithMany("BooksAuthors")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library.Domain.Entities.RecordEntity", b =>
                {
                    b.HasOne("Library.Domain.Entities.BookInsatnceEntity", "BookInsatnce")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.LibrarianEntity", "Librarian")
                        .WithMany()
                        .HasForeignKey("LibrarianID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.ReaderEntity", "Reader")
                        .WithMany()
                        .HasForeignKey("ReaderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookInsatnce");

                    b.Navigation("Librarian");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Library.Domain.Entities.AuthorEntity", b =>
                {
                    b.Navigation("BooksAuthors");
                });

            modelBuilder.Entity("Library.Domain.Entities.BookEntity", b =>
                {
                    b.Navigation("BooksAuthors");
                });
#pragma warning restore 612, 618
        }
    }
}
