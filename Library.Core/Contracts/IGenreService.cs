using System;
using Library.Core.DTOs;

namespace Library.Core.contracts;

public interface IGenreService
{
    Task<GenreDto> SaveAsync(GenreDto item);
    Task<IEnumerable<GenreDto>> ListAll();
    Task<GenreDto> GetAsync(int genreId);
    Task<IEnumerable<BookDto>> ListBookByGenre(int genreId);

}
