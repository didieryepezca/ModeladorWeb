using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        [Key]
        [Display(Name = "ID de Usuario")]
        public String UserId { get; set; }

        [Display(Name = "ID del Rol")]
        public String RoleId { get; set; }

    }
}
