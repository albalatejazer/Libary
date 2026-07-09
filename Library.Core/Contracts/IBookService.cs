using System;
using Library.Core.Contracts;
using Library.Core.Data.Models;
using Library.Core.DTOs;

namespace Library.Core.contracts;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooks();
    Task<BookDto> GetBook(int bookId);
    Task<BookDto> SaveAsync(BookDto item);
    Task<IEnumerable<BookDto>> SearchByKey(string sKey, string sBy);
    Task<BookDto> UpdateAsync(BookDto item);

    Task<BookAuthorDto> SaveAsync(BookAuthorDto item);
    // Task<BookAuthorDto> GetAsync(int bookAuthorId);
    Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int authorId);

}
