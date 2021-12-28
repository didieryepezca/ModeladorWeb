using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_TREE_STYLE
    {
        [Key]
        [Display(Name = "ID del Estilo")]
        public int StyleID { get; set; }
        public int NivelID { get; set; }
        public string campo { get; set; }
        public string style { get; set; }
    }
}
