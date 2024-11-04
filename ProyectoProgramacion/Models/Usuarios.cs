using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramacion.Models
{
    public class Usuarios
    {
        [Key]
        public int ID_usuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
