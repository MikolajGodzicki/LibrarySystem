using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LibraryApp.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int UserID { get; set; }

        [ValidateNever]
        public virtual User User { get; set; } = default!;
        public int BookCopyID { get; set; }

        [ValidateNever]
        public virtual BookCopy BookCopy { get; set; } = default!;
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
