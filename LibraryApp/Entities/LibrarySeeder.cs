using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Entities {
    public class LibrarySeeder {
        private LibraryDbContext _context;

        public LibrarySeeder(LibraryDbContext context) {
            _context = context;
        }

        public void SeedDbValues() {
            if (!_context.Database.CanConnect()) {
                return;     // Can't connect to database 
            }

            if (_context.Users.Any() || _context.Books.Any() || _context.BookCopies.Any() || _context.Loans.Any()) {
                return;    // Data was already seeded.
            }

            // Seed Books
            var books = new[]
            {
                    new Book { Title = "Harry Potter", Author = "J.K. Rowling", Genre = "Fantasy", PublishedYear = 1997, Available = true },
                    new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Classic", PublishedYear = 1960, Available = true },
                    new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic", PublishedYear = 1925, Available = true }
               };
            _context.Books.AddRange(books);
            _context.SaveChanges();

            // Seed BookCopies
            var bookCopies = new[]
            {
                    new BookCopy { BookID = books[0].Id, IsAvailable = true },
                    new BookCopy { BookID = books[0].Id, IsAvailable = true },
                    new BookCopy { BookID = books[1].Id, IsAvailable = true }
                };
            _context.BookCopies.AddRange(bookCopies);
            _context.SaveChanges();
        }
    }
}
