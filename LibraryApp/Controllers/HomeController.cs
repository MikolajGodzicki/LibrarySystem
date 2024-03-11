using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Entities;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class HomeController : BaseAuthenticatorController
    {
        public HomeController(LibraryDbContext context) : base(context)
        {
        }

        // GET: Books
        public IActionResult Index()
        {
            bool isAuthenticated = IsUserAuthenticated();
            ViewData["IsAuthenticated"] = isAuthenticated;
            if (!isAuthenticated)
            {
                return RedirectToLogin();
            }

            ViewData["Username"] = GetUser().Username;

            IEnumerable<BookListModel> _bookList = GetBookListModels();

            return View(_bookList);
        }

        private IEnumerable<BookListModel> GetBookListModels()
        {
            var books = _context.Books.Include(b => b.BookCopies).ToList();

            foreach (var _book in books)
            {
                yield return new BookListModel()
                {
                    Book = _book,
                    IsAvailable = _book.BookCopies.Any(bc => bc.IsAvailable)
                };
            }
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books.FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Author,Genre,PublishedYear,Available")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Rent/5
        public IActionResult Rent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books.Include(b => b.BookCopies).FirstOrDefault(b => b.Id == id && b.Available);
            if (book == null || !book.BookCopies.Any(bc => bc.IsAvailable))
            {
                TempData["AlertMessage"] = "Nie ma żadnej kopii do wypożyczenia!";
                return RedirectToHome();
            }

            var bookModel = new BookListModel()
            {
                Book = book,
                IsAvailable = book.BookCopies.Any(bc => bc.IsAvailable)
            };

            return View(bookModel);
        }

        // POST: Books/Rent/5
        [HttpPost, ActionName("Rent")]
        [ValidateAntiForgeryToken]
        public IActionResult RentConfirmed(int id)
        {
            var _book = _context.Books.Find(id);
            if (_book is not null)
            {
                var _bookCopy = _context.BookCopies.FirstOrDefault(b => b.BookID == _book.Id && b.IsAvailable);
                if (_bookCopy is not null)
                {
                    _bookCopy.IsAvailable = false;
                }
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Author,Genre,PublishedYear,Available")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books.FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
