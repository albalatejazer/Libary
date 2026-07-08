public class BookDetailsDto
{
    public int BookId { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public int PublishYear { get; set; }
    public string Edition { get; set; } = string.Empty;
    public string ShelfCode { get; set; } = string.Empty;
    public List<string> Authors { get; set; } = [];
    public List<string> Genres { get; set; } = [];
}