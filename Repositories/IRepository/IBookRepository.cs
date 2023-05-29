using BookStore.Models;

namespace BookStore.Repositories.IRepository
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();
        public Task<BookModel> GetBookAsync(int id);
        public Task<int> AddBookAsync(BookModel book);
        public Task UpdateBookAsync(int id, BookModel book);
        public Task<string> DeleteBookAsync(int id);
    }
}
