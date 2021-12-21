using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_TREE
    {       
        [Display(Name = "Nombre")]
        public string title { get; set; }       
        public bool lazy { get; set; }
        [Key]       
        public int id { get; set; }
        public int parentId { get; set; }      
        public int proyectoId { get; set; }

        [DisplayFormat(DataFormatString = "{0:ddd, d MMMM yyyy, hh:mm tt}")]
        public DateTime fechaCreacion { get; set; }
        public string descripcion { get; set; }
    }
}
