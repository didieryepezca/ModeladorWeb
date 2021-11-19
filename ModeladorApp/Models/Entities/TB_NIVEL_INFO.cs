using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_NIVEL_INFO
    {
        [Key]
        [Display(Name = "ID Info")]
        public int InfoID { get; set; }
        public int NivelID { get; set; }

        [Display(Name = "Información")]
        public string Informacion { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime FechaIngreso { get; set; }
    }
}
