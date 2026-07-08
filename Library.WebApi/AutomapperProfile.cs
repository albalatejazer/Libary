using System;
using AutoMapper;
using Library.Core.Data.Models;
using Library.Core.DTOs;

namespace Library.WebApi;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, BookDetailsDto>().ReverseMap();
        CreateMap<BookAuthor, BookAuthorDto>().ReverseMap();
        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<BookGenre, BookGenreDto>().ReverseMap();
        CreateMap<ShelfLocation, ShelfLocationDto>().ReverseMap();
        CreateMap<Borrowing, BorrowingDto>().ReverseMap();
    }

}
