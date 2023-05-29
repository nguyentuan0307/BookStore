using AutoMapper;
using BookStore.Data;
using BookStore.Exceptions;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddBookAsync(BookModel book)
        {
            var newBook = _mapper.Map<Book>(book);
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<string> DeleteBookAsync(int id)
        {
            var deleteBook = _context.Books.SingleOrDefault(book => book.Id == id);
            if (deleteBook != null)
            {
                var title = deleteBook.Title; // Lưu trữ tên cuốn sách
                _context.Books.Remove(deleteBook);
                await _context.SaveChangesAsync();
                return title;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel> GetBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        public async Task UpdateBookAsync(int id, BookModel book)
        {
            if (id == book.Id)
            {
                var updateBook = _mapper.Map<Book>(book);
                _context.Books.Update(updateBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
