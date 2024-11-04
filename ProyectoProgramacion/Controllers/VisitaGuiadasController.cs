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
    public class VisitaGuiadasController : Controller
    {
        private readonly GimnasioContext _context;

        public VisitaGuiadasController(GimnasioContext context)
        {
            _context = context;
        }

        // GET: VisitaGuiadas
        public async Task<IActionResult> Index()
        {
            return View(await _context.VisitaGuiada.ToListAsync());
        }

        // GET: VisitaGuiadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaGuiada = await _context.VisitaGuiada
                .FirstOrDefaultAsync(m => m.IdTour == id);
            if (visitaGuiada == null)
            {
                return NotFound();
            }

            return View(visitaGuiada);
        }

        // GET: VisitaGuiadas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VisitaGuiadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTour,Nombres,CorreoElectronico,Telefono")] VisitaGuiada visitaGuiada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitaGuiada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitaGuiada);
        }

        // GET: VisitaGuiadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaGuiada = await _context.VisitaGuiada.FindAsync(id);
            if (visitaGuiada == null)
            {
                return NotFound();
            }
            return View(visitaGuiada);
        }

        // POST: VisitaGuiadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTour,Nombres,CorreoElectronico,Telefono")] VisitaGuiada visitaGuiada)
        {
            if (id != visitaGuiada.IdTour)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitaGuiada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaGuiadaExists(visitaGuiada.IdTour))
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
            return View(visitaGuiada);
        }

        // GET: VisitaGuiadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaGuiada = await _context.VisitaGuiada
                .FirstOrDefaultAsync(m => m.IdTour == id);
            if (visitaGuiada == null)
            {
                return NotFound();
            }

            return View(visitaGuiada);
        }

        // POST: VisitaGuiadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitaGuiada = await _context.VisitaGuiada.FindAsync(id);
            if (visitaGuiada != null)
            {
                _context.VisitaGuiada.Remove(visitaGuiada);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaGuiadaExists(int id)
        {
            return _context.VisitaGuiada.Any(e => e.IdTour == id);
        }
    }
}
