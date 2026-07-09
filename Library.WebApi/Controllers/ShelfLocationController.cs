using Library.Core.contracts;
using Library.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfLocationController : ControllerBase
    {
        private readonly IShelfLocationService _service;

        public ShelfLocationController(IShelfLocationService service)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(typeof(ShelfLocationDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<ShelfLocationDto>> SaveAsync([FromBody] ShelfLocationDto item)
        {
            var res = await _service.SaveAsync(item);
            return res;
        }

        [HttpGet("GetLocationByBookId")]
        [ProducesResponseType(typeof(ShelfLocationDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShelfLocationDto>> GetBookLocation(int bookId)
        {
            var res = await _service.GetBookLocation(bookId);
            return Ok(res);
        }
    }
}
