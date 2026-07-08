namespace Library.Core.DTOs;

public class BorrowingDto
{
    public int BorrowId { get; set; }
    public int BookId { get; set; }
    public string BorrowName { get; set; } = string.Empty;
    public DateOnly BorrowDate { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly? ReturnDate { get; set; }
    public string Status { get; set; } = string.Empty;  
}