using System.ComponentModel;

namespace LibraryAPI.Entities
{
    public class Book
    {
        public int BookID { get; set; }

        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [DisplayName("Autor")]
        public string Author { get; set; }

        [DisplayName("Gatunek")]
        public string Genre { get; set; }

        [DisplayName("Rok wydania")]
        public int PublishedYear { get; set; }

        [DisplayName("Dostępność")]
        public bool Available { get; set; }

        public ICollection<BookCopy> BookCopies { get; set; }
    }
}
