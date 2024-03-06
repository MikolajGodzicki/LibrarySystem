using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LibraryApp.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsAdmin { get; set; }

        [ValidateNever]
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
