using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Entities
{
    public class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        [DisplayName("Nazwa")]
        public string Username { get; set; } = default!;
        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        [DisplayName("Hasło")]
        public string Password { get; set; } = default!;
        [NotMapped]
        [Compare("Password")]
        [Required(ErrorMessage = "Pole Potwierdź Hasło jest wymagane")]
        [DisplayName("Potwierdź Hasło")]
        public string ConfirmPassword { get; set; } = default!;
        [Required(ErrorMessage = "Pole E-Mail jest wymagane")]
        [DisplayName("E-Mail")]
        public  string Email { get; set; } = default!;
        [ValidateNever]
        public bool IsAdmin { get; set; }

        [ValidateNever]
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
