using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace LibraryApp.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public string UserID { get; set; }

        [ValidateNever]
        public virtual User User { get; set; } = default!;
        public int BookCopyID { get; set; }

        [ValidateNever]
        public virtual BookCopy BookCopy { get; set; } = default!;
        [DisplayName("Data Wypożyczenia")]
        public DateTime LoanDate { get; set; }
        [DisplayName("Data Oddania")]
        public DateTime ReturnDate { get; set; }
    }
}
