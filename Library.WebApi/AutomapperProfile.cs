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

        // Entity → DTO
        // CreateMap<Book, BookDto>();
        // CreateMap<Author, AuthorDto>();

        CreateMap<BookAuthor, BookAuthorDto>()
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Book))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Author));

        // DTO → Entity (reverse mapping)
        // CreateMap<BookDto, Book>();
        // CreateMap<AuthorDto, Author>();

        CreateMap<BookAuthorDto, BookAuthor>()
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Books))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Authors));
    }

}
