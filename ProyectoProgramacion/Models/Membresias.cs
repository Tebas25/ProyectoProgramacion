using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramacion.Models
{
    public class Membresias
    {
        [Key]
        public int IDcliente { get; set; }
        [MaxLength(10)]
        [MinLength(10)]
        public string cedula { get; set; }
        public string nombre { get; set; }
        [ForeignKey("TiposMembresia")]
        public int TiposMembresia { get; set; }
        public TiposMembresia? membresia { get; set; }
        public DateTime caducidad {  get; set; }
    }
}
