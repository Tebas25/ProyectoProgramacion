using Npgsql;
namespace ProyectoProgramacion
{
    public class ConexionBD
    {
        private NpgsqlConnection conn;

        public ConexionBD()
        {
            conn = new NpgsqlConnection("Server=localhost;Database=ProyectoP1Context-45101263-63b1-49cb-80b0-2a5e63733d20;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        public NpgsqlConnection Abrir_Conexion()
        {
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Cerrar_Conexion()
        {
            conn.Close();
        }
    }
}
