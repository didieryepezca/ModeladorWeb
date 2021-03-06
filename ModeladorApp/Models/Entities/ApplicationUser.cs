using System;

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

        //public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        //public string inicialesNombres {

        //    get { return Nombres.Substring(0, 1) + Apellidos.Substring(0, 1);  }

        //}
    }
}
