using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacion.Controllers
{
    public class PremiumController : Controller
    {
        private readonly ProyectoP1Context _context;

        public PremiumController(ProyectoP1Context context)
        {
            _context = context;
        }
        
        
            public async Task<IActionResult> Premium()
            {
            var Premium = await _context.Membresias
            .Where(e => e.membresia.Tipo == "Premium")
            .ToListAsync();
            return View(Premium);
        }
        
    }
}

