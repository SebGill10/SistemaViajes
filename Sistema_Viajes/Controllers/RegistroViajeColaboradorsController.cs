using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Viajes.Context;
using Sistema_Viajes.Models;

namespace Sistema_Viajes.Controllers
{
    public class RegistroViajeColaboradorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroViajeColaboradorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroViajeColaboradors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroViajeColaboradores.Include(r => r.Colaborador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroViajeColaboradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroViajeColaboradores == null)
            {
                return NotFound();
            }

            var registroViajeColaborador = await _context.RegistroViajeColaboradores
                .Include(r => r.Colaborador)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (registroViajeColaborador == null)
            {
                return NotFound();
            }

            return View(registroViajeColaborador);
        }

        // GET: RegistroViajeColaboradors/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido");
            return View();
        }

        // POST: RegistroViajeColaboradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViajeId,ColaboradorId")] RegistroViajeColaborador registroViajeColaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroViajeColaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido", registroViajeColaborador.ColaboradorId);
            return View(registroViajeColaborador);
        }

        // GET: RegistroViajeColaboradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroViajeColaboradores == null)
            {
                return NotFound();
            }

            var registroViajeColaborador = await _context.RegistroViajeColaboradores.FindAsync(id);
            if (registroViajeColaborador == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido", registroViajeColaborador.ColaboradorId);
            return View(registroViajeColaborador);
        }

        // POST: RegistroViajeColaboradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViajeId,ColaboradorId")] RegistroViajeColaborador registroViajeColaborador)
        {
            if (id != registroViajeColaborador.ColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroViajeColaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroViajeColaboradorExists(registroViajeColaborador.ColaboradorId))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido", registroViajeColaborador.ColaboradorId);
            return View(registroViajeColaborador);
        }

        // GET: RegistroViajeColaboradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroViajeColaboradores == null)
            {
                return NotFound();
            }

            var registroViajeColaborador = await _context.RegistroViajeColaboradores
                .Include(r => r.Colaborador)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (registroViajeColaborador == null)
            {
                return NotFound();
            }

            return View(registroViajeColaborador);
        }

        // POST: RegistroViajeColaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroViajeColaboradores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegistroViajeColaboradores'  is null.");
            }
            var registroViajeColaborador = await _context.RegistroViajeColaboradores.FindAsync(id);
            if (registroViajeColaborador != null)
            {
                _context.RegistroViajeColaboradores.Remove(registroViajeColaborador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroViajeColaboradorExists(int id)
        {
          return (_context.RegistroViajeColaboradores?.Any(e => e.ColaboradorId == id)).GetValueOrDefault();
        }
    }
}
