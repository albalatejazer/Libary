using System;
using Library.Core.DTOs;

namespace Library.Core.contracts;

public interface IShelfLocationService
{
    Task<ShelfLocationDto> SaveAsync(ShelfLocationDto item);
    Task<ShelfLocationDto> GetBookLocation(int bookId);

}
