using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Data.Models;

[Index(nameof(GenreName), IsUnique = true)]
public class Genre
{
    [Key]
    public int GenreId { get; set; }
    public string GenreName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}