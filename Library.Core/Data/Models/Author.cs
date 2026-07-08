using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Data.Models;

[Index(nameof(LastName), nameof(FirstName))]
public class Author
{
    [Key]
    public int AuthorId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    // public string Biography { get; set; } = string.Empty;
    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}