using Library.Core.contracts;
using Library.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService _service;

        public BorrowingController(IBorrowingService service)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(typeof(BorrowingDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<BorrowingDto>> SaveAsync([FromBody] BorrowingDto item)
        {
            var res = await _service.SaveAsync(item);
            return res;
        }
        [HttpGet("{bookId}")]
        [ProducesResponseType(typeof(BorrowingDto), StatusCodes.Status200OK)]
        public async Task<BorrowingDto> GetBorrowingDtlByBookId(int bookId)
        {
            var res = await _service.GetAsync(bookId);
            return res;
        }
        [HttpGet("GetReaders")]
        [ProducesResponseType(typeof(BorrowingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<BorrowingDto>> GetReadersByBookId(int bookId)
        {
            var res = await _service.GetReadersByBookId(bookId);
            return Ok(res);
        }


    }
}
