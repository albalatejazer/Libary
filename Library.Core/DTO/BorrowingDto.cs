namespace Library.Core.DTOs;

public class BorrowingDto
{
    public int BorrowId { get; set; }
    public int BookId { get; set; }
    public string BorrowName { get; set; } = string.Empty;
    public DateOnly? BorrowDate { get; set; } = null;
    public DateOnly? ReturnDate { get; set; }
}