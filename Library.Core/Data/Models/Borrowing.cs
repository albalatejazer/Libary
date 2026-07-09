using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Core.Data.Models;

public class Borrowing
{
    [Key]
    public int BorrowId { get; set; }
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    public required string BorrowName { get; set; }
    public DateOnly BorrowDate { get; set; }
    public DateOnly? ReturnDate { get; set; } = null;
    public virtual Book? Book { get; set; }
}