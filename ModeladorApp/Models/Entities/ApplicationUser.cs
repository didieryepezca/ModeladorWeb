using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }

        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }

        public string UsuarioNombreCompleto
        {
            get { return Nombres + " " + Apellidos; }
        }
    }
}
