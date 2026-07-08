using AutoMapper;
using AutoMapper.QueryableExtensions;
using Humanizer;
using Library.Core.contracts;
using Library.Core.Contracts;
using Library.Core.Data;
using Library.Core.Data.Models;
using Library.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public BookService(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDto>> SearchByKey(string sKey, string sBy)
        {
            // if (string.IsNullOrEmpty(sKey) || string.IsNullOrEmpty(sBy)) return null;
            IQueryable<Book> query = _ctx.Books;

            switch (sBy.ToLower())
            {
                case "isbn":
                    query = query.Where(x => x.ISBN.StartsWith(sKey.ToLower()));
                    break;
                case "title":
                    query = query.Where(x => x.Title.ToLower().StartsWith(sKey.ToLower()));
                    break;
                case "publishyear":
                    query = query = query.Where(b => b.PublishYear.ToString().StartsWith(sKey));
                    break;

                default:
                    return Enumerable.Empty<BookDto>();
            }

            var result = await query
                    .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            return result;
        }


        #region CRUD
        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            var books = await _ctx.Books.ToListAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
        public async Task<BookDto> GetBook(int bookId)
        {
            var books = await _ctx.Books.FirstOrDefaultAsync(x => x.BookId == bookId);
            return _mapper.Map<BookDto>(books);
        }
        public async Task<BookDto> SaveAsync(BookDto item)
        {
            var obj = _mapper.Map<Book>(item);
            await _ctx.Books.AddAsync(obj);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<BookDto>(obj);
        }
        #endregion
    }
}
