namespace Library.Core.DTOs;

public class BookDto
{
    public int BookId { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public int PublishYear { get; set; }
    public string Edition { get; set; } = string.Empty;
    public int? ShelfId { get; set; }
}
