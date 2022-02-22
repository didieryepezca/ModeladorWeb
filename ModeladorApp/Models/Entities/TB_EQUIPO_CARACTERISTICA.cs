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

        [Display(Name = "NCR")]
        public decimal NRC_CARACTERISTICA { get; set; }

        [Display(Name = "Cantidad")]
        public decimal CANT_CARACTERISTICA { get; set; }

        [Display(Name = "UND")]
        public string UND_CARACTERISTICA { get; set; }       

        [Display(Name = "Descuento 1")]
        public decimal DESC1_CARACTERISTICA { get; set; }

        [Display(Name = "SubTotal 1")]
        public decimal SUB_TOTAL1 { get; set; }

        [Display(Name = "MRC")]
        public decimal MRC_CARACTERISTICA { get; set; }

        [Display(Name = "Descuento 2")]
        public decimal DESC2_CARACTERISTICA { get; set; }

        [Display(Name = "SubTotal 2")]
        public decimal SUB_TOTAL2 { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime FECHA_REGISTRO { get; set; }

        [Display(Name = "Usuario")]
        public string USUARIO { get; set; }
    }
}
