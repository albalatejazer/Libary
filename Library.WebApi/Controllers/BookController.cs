using Library.Core.contracts;
using Library.Core.Data.Models;
using Library.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _service.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{bookId}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBook(int bookId)
        {
            var books = await _service.GetBook(bookId);
            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<BookDto>> SaveAsync([FromBody] BookDto item)
        {
            var book = await _service.SaveAsync(item);
            return CreatedAtAction(nameof(GetBook), new { bookId = book?.BookId }, book);
        }
        [HttpGet("SearchByKey")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDto>>> SearchByKey([FromQuery] string sKey, [FromQuery] string sBy)
        {
            if (string.IsNullOrEmpty(sKey) || string.IsNullOrEmpty(sBy)) return BadRequest("Required parameter is missing!");

            var res = await _service.SearchByKey(sKey, sBy);
            return Ok(res);
        }
        [HttpPut("updateBookShelfLocation")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<BookDto>> UpdateAsync([FromBody] BookDto item)
        {
            var res = await _service.UpdateAsync(item);
            return res;
        }
        
        [HttpPost("BookAuthor")]
        public async Task<ActionResult<BookAuthorDto>> SaveAsync([FromBody] BookAuthorDto item)
        {
            var res = await _service.SaveAsync(item);
            return res;
        }
        [HttpGet("GetBooksByAuthor/{authorId}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDto>> GetBooksByAuthor(int authorId)
        {
            var res = await _service.GetBooksByAuthorAsync(authorId);
            return Ok(res);
        }
    }
}
