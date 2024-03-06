using LibraryAPI.Entities;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private IBooksService _bookService;
        
        public BooksController(IBooksService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookService.GetBooks());
        }


        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            Book? book = _bookService.GetBook(id);

            if (book == null)
            {
                return BadRequest();
            }

            return Ok(book);
        }
    }
}
