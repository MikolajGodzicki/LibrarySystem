using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Entities
{
    public class BookCopy
    {
        public int Id { get; set; }

        public int BookID { get; set; }

        [ValidateNever]
        public virtual Book Book {  get; set; }
        [DisplayName("Dostępność")]
        public bool IsAvailable { get; set; }

        [ValidateNever]
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
