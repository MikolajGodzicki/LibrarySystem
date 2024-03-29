using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models {
    public class UserLoginModel {
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        [DisplayName("Nazwa")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        [DisplayName("Hasło")]
        public string Password { get; set; } = default!;
    }
}
