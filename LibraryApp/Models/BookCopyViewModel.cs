using LibraryApp.Entities;
using System.ComponentModel;

namespace LibraryApp.Models
{
    public class BookCopyViewModel
    {
        public Book Book { get; set; }

        [DisplayName("Dostępność")]
        public bool Available {  get; set; }
    }
}
