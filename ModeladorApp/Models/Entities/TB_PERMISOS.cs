using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeladorApp.Models.Entities
{
    public class TB_PERMISOS
    {
        [Key]
        [Display(Name = "ID Permiso")]
        public int PermisoID { get; set; }

        [Display(Name = "ID de Proyecto")]
        [ForeignKey("TB_PROYECTO")]
        public int ProyectoID { get; set; }
        public virtual TB_PROYECTO TB_PROYECTO { get; set; }
        public string UsuarioCreacionId { get; set; }

        [Display(Name = "Usuario que creo")]
        public string UsuarioCreacionName { get; set; }

        [Display(Name = "Permiso")]
        public string Permiso { get; set; }        
        public string UsuarioConcedidoId { get; set; }

        [Display(Name = "Usuario concedido")]
        public string UsuarioConcedidoName { get; set; }

        [Display(Name = "Fecha de Creación")]
        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime FechaPermisoCreado { get; set; }      
    }
}
