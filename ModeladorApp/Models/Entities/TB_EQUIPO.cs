using System;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_EQUIPO
    {
        [Key]
        [Display(Name = "ID EQUIPO")]
        public int ID_EQUIPO { get; set; }

        [Display(Name = "Nombre")]
        public string NOMBRE_EQUIPO { get; set; }

        [Display(Name = "NCR")]
        public decimal NCR_EQUIPO { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime FECHA_REGISTRO { get; set; }

        [Display(Name = "Usuario")]
        public string USUARIO { get; set; }
    }
}
