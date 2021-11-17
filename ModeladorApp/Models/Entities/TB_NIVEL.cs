using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ModeladorApp.Models.Entities
{
    public class TB_NIVEL
    {
        [Key]
        [Display(Name = "ID Nivel")]
        public int NivelID { get; set; }
        public int ParentNivelID { get; set; }

        [Display(Name = "Identificador")]
        public string Identificador { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "ID Usuario")]
        public string UsuarioId { get; set; }

        [Display(Name = "Fecha de Creacion")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime FechaCreacion { get; set; }

    }
}
