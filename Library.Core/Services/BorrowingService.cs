using System;
using AutoMapper;
using Library.Core.contracts;
using Library.Core.Data;
using Library.Core.Data.Models;
using Library.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.services;

public class BorrowingService : IBorrowingService
{
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public BorrowingService(DataContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }
    public async Task<BorrowingDto> SaveAsync(BorrowingDto item)
    {
        var obj = _mapper.Map<Borrowing>(item);
        obj.ReturnDate = null;
        await _ctx.Borrowings.AddAsync(obj);
        await _ctx.SaveChangesAsync();
        return _mapper.Map<BorrowingDto>(obj);
    }
    public async Task<BorrowingDto> UpdateAsync(BorrowingDto item)
    {
        var obj = await _ctx.Borrowings.Where(x => x.BorrowId == item.BorrowId && x.ReturnDate == null).FirstOrDefaultAsync();
        _mapper.Map(item, obj);
        await _ctx.SaveChangesAsync();
        return _mapper.Map<BorrowingDto>(obj);
    }
    // public async Task<BorrowingDto> UpdateById(int bookId)
    // {
    //     var obj = await _ctx.Borrowings.Where(x => x.BorrowId == bookId && x.ReturnDate == null).FirstOrDefaultAsync();
    //     _mapper.Map(item, obj);
    //     await _ctx.SaveChangesAsync();
    //     return _mapper.Map<BorrowingDto>(obj);
    // }
    public async Task<BorrowingDto> GetAsync(int bookId)
    {
        var res = await _ctx.Borrowings.AsNoTracking()
                                        .Where(x => x.BookId == bookId && x.ReturnDate == null)
                                        .FirstOrDefaultAsync();

        return _mapper.Map<BorrowingDto>(res);
    }
    public async Task<IEnumerable<BorrowingDto>> GetReadersByBookId(int bookId)
    {
        var res = await _ctx.Borrowings.Where(x => x.BookId == bookId).ToListAsync();
        return _mapper.Map<IEnumerable<BorrowingDto>>(res);
    }
}
