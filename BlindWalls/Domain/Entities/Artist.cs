﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "U moet een gebruikersnaam invoeren!")]
        [Display(Name = "Gebruikersnaam")]
        public String ArtistName { get; set; }
        public virtual ICollection<Mural> Murals { get; set; }
        public virtual Account Account { get; set; }
    }
}
