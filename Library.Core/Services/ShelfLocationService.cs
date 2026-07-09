using System;
using AutoMapper;
using Library.Core.contracts;
using Library.Core.Data;
using Library.Core.Data.Models;
using Library.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.services;

public class ShelfLocationService : IShelfLocationService
{
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public ShelfLocationService(DataContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }
    public async Task<ShelfLocationDto> SaveAsync(ShelfLocationDto item)
    {
        var obj = _mapper.Map<ShelfLocation>(item);
        await _ctx.ShelfLocations.AddAsync(obj);
        await _ctx.SaveChangesAsync();
        return _mapper.Map<ShelfLocationDto>(obj);
    }
    public async Task<ShelfLocationDto> GetBookLocation(int bookId)
    {
        var res = await _ctx.Books.AsNoTracking()
                                .Where(x => x.BookId == bookId)
                                .Include(x => x.ShelfLocation)
                                .FirstOrDefaultAsync();
        return _mapper.Map<ShelfLocationDto>(res?.ShelfLocation);
    }
}
