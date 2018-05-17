using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manga.DATA.DAL;
using Manga.SERVICES.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manga.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly IBookServices bookService;

        public BookController(IBookServices bookServices)
        {
            this.bookService = bookServices;
        }

        [HttpGet("bookId")]
        public async Task<IActionResult> Get(Guid bookId)
        {
            var bookForDisplay = await bookService.GetBookAsync(bookId);
            if (bookForDisplay == null)
            {
                return BadRequest();
            }
            return Ok(bookForDisplay);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookForCreation bookForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var bookForDisplay = await bookService.AddBookAsync(bookForCreation);
            if (bookForCreation == null)
            {
                return StatusCode(500, "Fail with saving data");
            }

            return Ok(bookForDisplay);

        }

    }
}