using System;

using System.ComponentModel.DataAnnotations;

namespace ModeladorApp.Models.Entities
{
    public class TB_ARCHIVOS
    {
        [Key]
        [Display(Name = "Codigo")]
        public int codigo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(70, ErrorMessage = "El campo no debe exceder de 200 caracteres")]
        [Display(Name = "Estado proceso")]

        public string estado_archivo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(70, ErrorMessage = "El campo no debe exceder de 50 caracteres")]
        [Display(Name = "Archivo")]

        public string nombre_archivo { get; set; }


        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(200, ErrorMessage = "El campo no debe exceder de 50 caracteres")]
        [Display(Name = "Comentarios")]

        public string observaciones { get; set; }

        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Display(Name = "Fecha de Carga")]
        public DateTime fecha_carga { get; set; }

    }
}
