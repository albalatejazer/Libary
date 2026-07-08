using System;
using Library.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();
    public DbSet<BookGenre> BookGenres => Set<BookGenre>();
    public DbSet<Borrowing> Borrowings => Set<Borrowing>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<ShelfLocation> ShelfLocations => Set<ShelfLocation>();
}
