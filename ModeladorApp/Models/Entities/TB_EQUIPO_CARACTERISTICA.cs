using System;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_EQUIPO_CARACTERISTICA
    {
        [Key]
        [Display(Name = "ID EQUIPO C")]
        public int ID_EQUIPO_C { get; set; }
        public int ID_EQUIPO { get; set; }

        [Display(Name = "Caracteristica")]
        public string NOMBRE_CARACTERISTICA { get; set; }

        [Display(Name = "NCR Caracteristica")]
        public decimal NCR_CARACTERISTICA { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime FECHA_REGISTRO { get; set; }

        [Display(Name = "Usuario")]
        public string USUARIO { get; set; }
    }
}
