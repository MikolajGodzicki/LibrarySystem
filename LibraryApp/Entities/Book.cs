using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace LibraryApp.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [DisplayName("Tytuł")]
        public string Title { get; set; } = default!;

        [DisplayName("Autor")]
        public string Author { get; set; } = default!;

        [DisplayName("Gatunek")]
        public string Genre { get; set; } = default!;

        [DisplayName("Rok wydania")]
        public int PublishedYear { get; set; }

        [DisplayName("Dostępność")]
        public bool Available { get; set; }

        [ValidateNever]
        public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
