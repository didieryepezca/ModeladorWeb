using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_PROYECTO
    {
        [Key]
        [Display(Name = "ID de Proyecto")]
        public int ProyID { get; set; }

        [Display(Name = "Identificador")]
        public string Identificador { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public int ParentProyID { get; set; }
    }
}
