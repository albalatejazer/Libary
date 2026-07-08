using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Data.Models;

[Index(nameof(BookId), nameof(AuthorId), IsUnique = true)]
public class BookAuthor
{
    [Key]
    public int BookAuthorId { get; set; }
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public virtual Book? Book { get; set; }
    public virtual Author? Author { get; set; }
}