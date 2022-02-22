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
        public decimal NRC_EQUIPO { get; set; }

        [Display(Name = "Cantidad")]
        public decimal CANT_EQUIPO { get; set; }

        [Display(Name = "UND")]
        public string UND_EQUIPO { get; set; }

        [Display(Name = "Descuento 1")]
        public decimal DESC1_EQUIPO { get; set; }

        [Display(Name = "Sub Total 1")]
        public decimal SUB_TOTAL1_EQ { get; set; }

        [Display(Name = "MRC")]
        public decimal MRC_EQUIPO { get; set; }

        [Display(Name = "Descuento 2")]
        public decimal DESC2_EQUIPO { get; set; }

        [Display(Name = "Sub Total 2")]
        public decimal SUB_TOTAL2_EQ { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime FECHA_REGISTRO { get; set; }

        [Display(Name = "Usuario")]
        public string USUARIO { get; set; }
    }
}
