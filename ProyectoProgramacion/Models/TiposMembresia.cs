using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramacion.Models
{
    public class TiposMembresia
    {
        [Key]
        public int ID_Membresia { get; set; }
        public string Tipo { get; set; }

    }
}
