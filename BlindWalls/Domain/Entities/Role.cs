using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum RoleNames
    {
        Admin,
        Artist
    }
    public partial class Role
    {
        [Key]
        public int RoleID { get; set; }

        public String RoleDescription { get; set; }
        
        public RoleNames RoleName { get; set; }
    }
}
