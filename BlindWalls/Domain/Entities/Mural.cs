using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Mural
    {
        [Key]
        public int MuralId { get; set; }
        public String MuralName { get; set; }
        public String MuralDescription { get; set; }
        public String MuralLocation { get; set; }
        public virtual Artist Artist { get; set; }
        public int ArtistID { get; set; }

    }
}
