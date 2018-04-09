using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "U moet een gebruikersnaam invoeren!")]
        [Display(Name = "Gebruikersnaam")]
        public string Username { get; set; }

        [Required(ErrorMessage = "U moet een wachtwoord invoeren!")]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
    }
}
