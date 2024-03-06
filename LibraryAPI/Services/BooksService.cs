using LibraryAPI.Entities;

namespace LibraryAPI.Services
{
    public class BooksService : IBooksService
    {
        private LibraryDbContext _context;

        public BooksService(LibraryDbContext context)
        {
            _context = context;
        }

        public Book? GetBook(int id)
        {
            return _context.Books.FirstOrDefault(b => b.BookID == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }
    }
}
