using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_NIVEL_COLUMN_TITLES
    {
        [Key]
        [Display(Name = "ID Titulo")]
        public int TituloID { get; set; }
        public int proyectoID { get; set; }
        public string titulo { get; set; }
    }
}
