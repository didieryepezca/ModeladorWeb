using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_TREE
    {
        [Display(Name = "Título")]
        public string title { get; set; }
        public bool lazy { get; set; }
        [Key]       
        public int id { get; set; }
        public int parentId { get; set; }
    }
}
