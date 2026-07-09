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
        public async Task<BookDto> UpdateAsync(BookDto item)
        {
            var obj = await _ctx.Books.Where(x => x.BookId == item.BookId).FirstOrDefaultAsync();
            _mapper.Map(item, obj);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<BookDto>(obj);
        }
        #endregion


        #region BookAuthor
        public async Task<BookDto> GetBookByAuthorId(int authorId)
        {
            var books = await _ctx.BookAuthors
           .AsNoTracking()
           .Where(x => x.AuthorId == authorId)
           .Include(x => x.Book)
           .Select(x => x.Book)
           .ToListAsync();

            return _mapper.Map<BookDto>(books);
        }
        public async Task<BookAuthorDto> SaveAsync(BookAuthorDto item)
        {

            var obj = _mapper.Map<BookAuthor>(item);
            await _ctx.BookAuthors.AddAsync(obj);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<BookAuthorDto>(obj);
        }
        public async Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int authorId)
        {
            var books = await _ctx.BookAuthors
                .AsNoTracking()
                .Where(ba => ba.AuthorId == authorId)
                .Include(ba => ba.Book)       // load related Book
                .Select(ba => ba.Book)        // project only the Book entity
                .ToListAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        #endregion
    }
}
