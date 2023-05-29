using BookStore.Exceptions;
using BookStore.Models;
using BookStore.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BooksController(IBookRepository repo)
        {
            _bookRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBooksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.GetBookAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            try
            {
                var newBookId = await _bookRepo.AddBookAsync(bookModel);
                var book = await _bookRepo.GetBookAsync(newBookId);
                return book == null ? NotFound() : Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookModel bookModel)
        {
            try
            {
                await _bookRepo.UpdateBookAsync(id, bookModel);
                var book = await _bookRepo.GetBookAsync(id);
                return Ok(book);
            }
            catch { return BadRequest(); }

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var deletedBookTitle = await _bookRepo.DeleteBookAsync(id);
                if (deletedBookTitle != null)
                {
                    return Ok($"Cuốn sách '{deletedBookTitle}' đã được xóa");
                }
                else
                {
                    return NotFound("Cuốn sách không tồn tại");
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
