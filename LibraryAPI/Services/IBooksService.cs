using LibraryAPI.Entities;

namespace LibraryAPI.Services
{
    public interface IBooksService
    {
        public IEnumerable<Book> GetBooks();
        public Book? GetBook(int id);
    }
}
