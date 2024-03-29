using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models {
    public class UserRegisterModel {
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        [DisplayName("Nazwa")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Pole E-Mail jest wymagane")]
        [DisplayName("E-Mail")]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        [DisplayName("Hasło")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Pole Potwierdź Hasło jest wymagane")]
        [DisplayName("Potwierdź Hasło")]
        public string ConfirmPassword { get; set; } = default!;
    }
}
