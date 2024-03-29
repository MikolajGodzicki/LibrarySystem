using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Entities
{
    public class User : IdentityUser
    {
        [ValidateNever]
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
