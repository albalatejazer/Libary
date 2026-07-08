using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Data.Models;

[Index(nameof(BookId), nameof(GenreId), IsUnique = true)]
public class BookGenre
{
    [Key]
    public int BookGenreId { get; set; }
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    [ForeignKey(nameof(Genre))]
    public int GenreId { get; set; }
    public virtual Book? Book { get; set; }
    public virtual Genre? Genre { get; set; }
}