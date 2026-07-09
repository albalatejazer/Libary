using Library.Core.contracts;
using Library.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(typeof(GenreDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<GenreDto>> SaveAsync([FromBody] GenreDto item)
        {
            var res = await _service.SaveAsync(item);
            return Ok(item);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenreDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<GenreDto>> GetAsync(int id)
        {
            var res = await _service.GetAsync(id);
            return Ok(res);
        }
        [HttpGet]
        [ProducesResponseType(typeof(GenreDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAsync()
        {
            var res = await _service.ListAll();
            return Ok(res);
        }
        [HttpGet("GetBooksByGenre")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDto>> ListBooksByGenre(int genreId)
        {
            var res = await _service.ListBookByGenre(genreId);
            return Ok(res);
        }

    }
}
