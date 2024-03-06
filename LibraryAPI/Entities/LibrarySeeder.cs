using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Entities
{
    public class LibrarySeeder
    {
        private LibraryDbContext _context;

        public LibrarySeeder(LibraryDbContext context)
        {
            _context = context;
        }

        public void SeedDbValues()
        {
            if (!_context.Database.CanConnect())
            {
                return;     // Can't connect to database 
            }

            if (_context.Users.Any() || _context.Books.Any() || _context.BookCopies.Any() || _context.Loans.Any())
            {
                return;    // Data was already seeded.
            }

            // Seed Users
            var users = new[]
                {
                    new User { Username = "user1", Password = "password1", Email = "user1@example.com", IsAdmin = false },
                    new User { Username = "user2", Password = "password2", Email = "user2@example.com", IsAdmin = false },
                    new User { Username = "admin", Password = "admin123", Email = "admin@example.com", IsAdmin = true }
                };
            _context.Users.AddRange(users);
            _context.SaveChanges();

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
                    new BookCopy { BookID = books[0].BookID, IsAvailable = true },
                    new BookCopy { BookID = books[0].BookID, IsAvailable = true },
                    new BookCopy { BookID = books[1].BookID, IsAvailable = true }
                };
            _context.BookCopies.AddRange(bookCopies);
            _context.SaveChanges();

            // Seed Loans
            _context.Loans.AddRange(
                new Loan { UserID = users[0].UserID, BookCopyID = bookCopies[0].BookCopyID, LoanDate = DateTime.Now.AddDays(-7), ReturnDate = DateTime.Now.AddDays(7) },
                new Loan { UserID = users[1].UserID, BookCopyID = bookCopies[1].BookCopyID, LoanDate = DateTime.Now.AddDays(-6), ReturnDate = DateTime.Now.AddDays(8) },
                new Loan { UserID = users[2].UserID, BookCopyID = bookCopies[2].BookCopyID, LoanDate = DateTime.Now.AddDays(-5), ReturnDate = DateTime.Now.AddDays(9) }
            );

            _context.SaveChanges();
        }
    }
}
