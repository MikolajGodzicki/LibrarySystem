using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        [DisplayName("Nazwa")]
        public string Username { get; set; } = default!;
        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        [DisplayName("Hasło")]
        public string Password { get; set; } = default!;
    }
}
