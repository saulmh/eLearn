using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearn.Models.ViewModels
{
    public class CursoViewModel
    {
        [Required]
        [Display(Name = "Nombre del curso")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Summary { get; set; }
        [Display(Name = "Fecha de inicio del curso")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Fecha de finalización")]
        public DateTime FinishDate { get; set; }
        [Display(Name = "Contraseña del curso")]
        public string Password { get; set; }
        [Display(Name = "Categoria")]
        public string Category { get; set; }

        // Numero de módulos
        [Display(Name = "Número de módulos")]
        public int Modules { get; set; }
    }
}
