using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlindWalls.Models
{
    public class LogInModel
    {
        [Display(Name = "Gebruikersnaam")]
        [Required(ErrorMessage = "U moet uw gebruikersnaam invullen!")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Display(Name = "Wachtwoord")]
        [Required(ErrorMessage = "U moet uw wachtwoord invullen!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}