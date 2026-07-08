using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Data.Models;

[Index(nameof(ShelfCode), IsUnique = true)]
public class ShelfLocation
{
    [Key]
    public int ShelfId { get; set; }
    public string ShelfCode { get; set; } = string.Empty;
    public string Floor { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public string Rack { get; set; } = string.Empty;
    public string Shelf { get; set; } = string.Empty;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}