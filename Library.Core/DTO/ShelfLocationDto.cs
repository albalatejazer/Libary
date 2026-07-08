namespace Library.Core.DTOs;

public class ShelfLocationDto
{
    public int ShelfId { get; set; }
    public string ShelfCode { get; set; } = string.Empty;
    public string Floor { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public string Rack { get; set; } = string.Empty;
    public string Shelf { get; set; } = string.Empty;
}