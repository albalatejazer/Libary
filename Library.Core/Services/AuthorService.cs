using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Core.Contracts;
using Library.Core.Data;
using Library.Core.Data.Models;
using Library.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;

public class AuthorService : IAuthorService
{
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;
    public AuthorService(DataContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }
    public async Task<IEnumerable<AuthorDto>> SearchByKey(string sKey)
    {
        var res = await _ctx.Authors.Where(x => x.FirstName.ToLower().StartsWith(sKey.ToLower()) ||
                    x.LastName.ToLower().StartsWith(sKey.ToLower())).ToListAsync();
        return _mapper.Map<IEnumerable<AuthorDto>>(res);
    }
    public async Task<IEnumerable<AuthorDto>> ListAuthors()
    {
        var res = await _ctx.Authors
                            .OrderBy(x => x.FirstName)
                            .ToListAsync();

        return _mapper.Map<IEnumerable<AuthorDto>>(res);
    }
    public async Task<AuthorDto> GetAuthorById(int authorId)
    {
        var res = await _ctx.Authors.AsNoTracking().FirstOrDefaultAsync(x => x.AuthorId == authorId);
        if (res == null) return null;
        return _mapper.Map<AuthorDto>(res);
    }
    public async Task<AuthorDto?> SaveAsync(AuthorDto? item)
    {
        if (item == null)
        {
            return null;
        }

        var obj = _mapper.Map<Author>(item);
        await _ctx.Authors.AddAsync(obj);
        await _ctx.SaveChangesAsync();

        return _mapper.Map<AuthorDto>(obj);
    }


}
