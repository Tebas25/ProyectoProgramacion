using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProyectoProgramacion.Models
{
    public class VisitaGuiada
    {
        [Key]
        public int IdTour { get; set; }
        [AllowNull]
        public string Nombres { get; set; }
        [EmailAddress]
        public string CorreoElectronico { get; set; }
        [Required]
        public DateTime Telefono { get; set; }


    }
}
