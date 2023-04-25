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
    public class ColaboradorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColaboradorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Colaboradors
        public async Task<IActionResult> Index()
        {
              return _context.Colaboradores != null ? 
                          View(await _context.Colaboradores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Colaboradores'  is null.");
        }

        // GET: Colaboradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.IdColaborador == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colaboradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdColaborador,Nombre,Apellido,Direccion")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaborador);
        }

        // GET: Colaboradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            return View(colaborador);
        }

        // POST: Colaboradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdColaborador,Nombre,Apellido,Direccion")] Colaborador colaborador)
        {
            if (id != colaborador.IdColaborador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.IdColaborador))
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
            return View(colaborador);
        }

        // GET: Colaboradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.IdColaborador == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colaboradores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Colaboradores'  is null.");
            }
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador != null)
            {
                _context.Colaboradores.Remove(colaborador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(int id)
        {
          return (_context.Colaboradores?.Any(e => e.IdColaborador == id)).GetValueOrDefault();
        }
    }
}
