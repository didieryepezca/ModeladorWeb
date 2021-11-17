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
        [Display(Name = "ID Proyecto")]
        public int ProyectoID { get; set; }        

        [Display(Name = "Nombre del Proyecto")]
        public string NombreProyecto { get; set; }

        [Display(Name = "Descripció del Proyecto")]
        public string DescripcionProyecto { get; set; }

        [Display(Name = "Fecha de Creacion")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime FechaCreado { get; set; }

        [Display(Name = "Fecha de Creacion")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]        
        public DateTime FechaUltimaEdicion { get; set; }

        [Display(Name = "ID de Propietario")]
        public string PropietarioID { get; set; }

        public ICollection<TB_PERMISOS> TB_PERMISOS { get; set; }
    }
}
