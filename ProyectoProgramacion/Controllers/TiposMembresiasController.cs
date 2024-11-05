using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion.Models;

namespace ProyectoProgramacion.Controllers
{
    public class TiposMembresiasController : Controller
    {
        private readonly ProyectoP1Context _context;

        public TiposMembresiasController(ProyectoP1Context context)
        {
            _context = context;
        }

        // GET: TiposMembresias
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposMembresia.ToListAsync());
        }

        // GET: TiposMembresias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposMembresia = await _context.TiposMembresia
                .FirstOrDefaultAsync(m => m.ID_Membresia == id);
            if (tiposMembresia == null)
            {
                return NotFound();
            }

            return View(tiposMembresia);
        }

        // GET: TiposMembresias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposMembresias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Membresia,Tipo")] TiposMembresia tiposMembresia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposMembresia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposMembresia);
        }

        // GET: TiposMembresias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposMembresia = await _context.TiposMembresia.FindAsync(id);
            if (tiposMembresia == null)
            {
                return NotFound();
            }
            return View(tiposMembresia);
        }

        // POST: TiposMembresias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Membresia,Tipo")] TiposMembresia tiposMembresia)
        {
            if (id != tiposMembresia.ID_Membresia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposMembresia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposMembresiaExists(tiposMembresia.ID_Membresia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tiposMembresia);
        }

        // GET: TiposMembresias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposMembresia = await _context.TiposMembresia
                .FirstOrDefaultAsync(m => m.ID_Membresia == id);
            if (tiposMembresia == null)
            {
                return NotFound();
            }

            return View(tiposMembresia);
        }

        // POST: TiposMembresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposMembresia = await _context.TiposMembresia.FindAsync(id);
            if (tiposMembresia != null)
            {
                _context.TiposMembresia.Remove(tiposMembresia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposMembresiaExists(int id)
        {
            return _context.TiposMembresia.Any(e => e.ID_Membresia == id);
        }
    }
}
