using System;
using Library.Core.DTOs;

namespace Library.Core.contracts;

public interface IBorrowingService
{
    Task<BorrowingDto> SaveAsync(BorrowingDto item);
    Task<BorrowingDto> UpdateAsync(BorrowingDto item);
    Task<BorrowingDto> GetAsync(int bookId);
    Task<IEnumerable<BorrowingDto>> GetReadersByBookId(int bookId);

}
