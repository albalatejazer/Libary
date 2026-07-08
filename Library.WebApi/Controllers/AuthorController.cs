using Library.Core.Contracts;
using Library.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> ListAuthors()
        {
            var res = await _service.ListAuthors();
            return Ok(res);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
        public async Task<AuthorDto> GetAuthorById(int id)
        {
            var res = await _service.GetAuthorById(id);
            return res;
        }
        [HttpGet("author/{name}")]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> SearchByKey(string name)
        {
            var res = await _service.SearchByKey(name);
            return Ok(res);
        }
        [HttpPost]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<AuthorDto>> SaveAsync([FromBody] AuthorDto item)
        {
            var res = _service.SaveAsync(item);
            return CreatedAtAction("GetAuthorById", new { authorId = item.AuthorId }, item);
        }
    }
}
