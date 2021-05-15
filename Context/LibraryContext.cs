using System;
using System.Configuration;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using WebApplication.Library.Models;

namespace WebApplication.Library.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<AuthorDto> Authors { get; set; }
        public DbSet<BookDto> Books { get; set; }
        public DbSet<GenreDto> Genres { get; set; }
        public DbSet<PersonDto> People { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }

        public LibraryContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorDto>().HasKey(p => p.AuthorId);
            modelBuilder.Entity<BookDto>().HasKey(p => p.BookId);
            modelBuilder.Entity<GenreDto>().HasKey(p => p.GenreId);
            modelBuilder.Entity<PersonDto>().HasKey(p => p.PersonId);
            modelBuilder.Entity<LibraryCard>().HasKey(p => p.LibraryCardId);

            modelBuilder.Entity<BookDto>()
                .HasMany(c => c.Genres)
                .WithMany(s => s.Books)
                .UsingEntity(j => j.ToTable("book_genre_lnk"));
                
            modelBuilder.Entity<BookDto>()
                  .HasRequired(c => c.BooksAuthor)
                  .WithOptional(c => c.AnAuthor);

            modelBuilder.Entity<LibraryCard>()
                  .HasRequired(c => c.PersonTookBook)
                  .WithOptional(c => c.APerson);
            modelBuilder.Entity<LibraryCard>()
                  .HasRequired(c => c.TakenBook)
                  .WithOptional(c => c.ABook);

            base.OnModelCreating(modelBuilder);
        }
    }
}
