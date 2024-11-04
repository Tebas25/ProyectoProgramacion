using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ProyectoProgramacion.Models;
using System.Diagnostics;

namespace ProyectoProgramacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy() 
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            bool chequeoUsuario= false;
            ConexionBD conexionBD= new ConexionBD();
            string query = "SELECT * FROM [ProyectoP1Context-45101263-63b1-49cb-80b0-2a5e63733d20].[dbo].[Usuarios] WHERE email= '"+email+"' AND password= '"+password+"'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conexionBD.Abrir_Conexion());

            using (NpgsqlDataReader reader = cmd.ExecuteReader()) 
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        chequeoUsuario = true;
                    }
                }
            }
            string jsonResponse = "";
            if (chequeoUsuario == true)
            {
                jsonResponse = "{\"status\":200, \"data\":{\"user\":\"" + email + "\"}";
            }
            else
            {
                jsonResponse = "{\"status\":200, \"data\":{\"ERROR, usuario inexistente\"}";
            }
            return Json(jsonResponse);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
