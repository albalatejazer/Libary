using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Data.Models;

[Index(nameof(ISBN), IsUnique = true)]
public class Book
{
    [Key]
    public int BookId { get; set; }
    public required string ISBN { get; set; }
    public required string Title { get; set; }
    public string Publisher { get; set; } = string.Empty;
    public int PublishYear { get; set; }
    [ForeignKey(nameof(ShelfLocation))]
    public int? ShelfId { get; set; }
    public virtual ShelfLocation? ShelfLocation { get; set; }
    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    public virtual ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}
