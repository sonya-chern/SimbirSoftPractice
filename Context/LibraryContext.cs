using Microsoft.EntityFrameworkCore;
using WebApplication.Library.Models;


namespace WebApplication.Library.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(p => p.AuthorId);
            modelBuilder.Entity<Book>().HasKey(p => p.BookId);
            modelBuilder.Entity<Genre>().HasKey(p => p.GenreId);
            modelBuilder.Entity<Person>().HasKey(p => p.PersonId);
            modelBuilder.Entity<LibraryCard>().HasKey(p => p.LibraryCardId);

            modelBuilder.Entity<Book>()
                .HasMany(c => c.Genres)
                .WithMany(s => s.Books)
                .UsingEntity(j => j.ToTable("book_genre_lnk"));

            modelBuilder.Entity<Book>()
                .HasOne(p => p.BooksAuthor)
                .WithMany(s => s.Books);

            modelBuilder.Entity<LibraryCard>()
                  .HasOne(c => c.APerson)
                  .WithOne(c => c.APerson);

            modelBuilder.Entity<Book>()
                  .HasOne(c => c.ABook)
                  .WithMany(c => c.Books);

            base.OnModelCreating(modelBuilder);
        }
    }
}
