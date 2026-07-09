using Library.Core.Data.Models;

namespace Library.Core.DTOs;

public class BookAuthorDto
{
    public int BookAuthorId { get; set; }
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public IEnumerable<BookDto>? Books { get; set; }
    public IEnumerable<AuthorDto>? Authors { get; set; }
}
public class FullBookAuthorDto
{
    public BookDto? Book { get; set; }
    public AuthorDto? MyProperty { get; set; }
}