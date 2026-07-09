using System;
using AutoMapper;
using Library.Core.contracts;
using Library.Core.Data;
using Library.Core.Data.Models;
using Library.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.services;

public class GenreService : IGenreService
{
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public GenreService(DataContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }
    public async Task<GenreDto> SaveAsync(GenreDto item)
    {
        var obj = _mapper.Map<Genre>(item);
        await _ctx.Genres.AddAsync(obj);
        await _ctx.SaveChangesAsync();
        return _mapper.Map<GenreDto>(obj);
    }
    public async Task<IEnumerable<GenreDto>> ListAll()
    {
        var res = await _ctx.Genres.ToListAsync();
        return _mapper.Map<IEnumerable<GenreDto>>(res);
    }
    public async Task<GenreDto> GetAsync(int genreId)
    {
        var res = await _ctx.Genres.FirstOrDefaultAsync(x => x.GenreId == genreId);
        return _mapper.Map<GenreDto>(res);
    }
    public async Task<IEnumerable<BookDto>> ListBookByGenre(int genreId)
    {
        var books = await _ctx.BookGenres.AsNoTracking()
                                        .Where(x => x.GenreId == genreId)
                                        .Include(x => x.Book)
                                        .Select(x => x.Book)
                                        .ToListAsync();
        return _mapper.Map<IEnumerable<BookDto>>(books);
    }

}

