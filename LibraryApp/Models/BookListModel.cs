using LibraryApp.Entities;

namespace LibraryApp.Models
{
    public class BookListModel
    {
        public Book Book { get; set; }
        public bool IsAvailable {  get; set; }
    }
}
