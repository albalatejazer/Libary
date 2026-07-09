using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Data.Models;
using Library.Core.DTOs;

namespace Library.Core.Contracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> ListAuthors();
        Task<AuthorDto> GetAuthorById(int authorId);
        Task<AuthorDto> SaveAsync(AuthorDto item);
        Task<IEnumerable<AuthorDto>> SearchByKey(string sKey);
    }
}