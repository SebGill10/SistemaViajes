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
    public class SucurrsalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucurrsalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sucurrsal
        public async Task<IActionResult> Index()
        {
              return _context.Sucurrsales != null ? 
                          View(await _context.Sucurrsales.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Sucurrsales'  is null.");
        }

        // GET: Sucurrsal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sucurrsales == null)
            {
                return NotFound();
            }

            var sucurrsal = await _context.Sucurrsales
                .FirstOrDefaultAsync(m => m.IdSucurrsal == id);
            if (sucurrsal == null)
            {
                return NotFound();
            }

            return View(sucurrsal);
        }

        // GET: Sucurrsal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sucurrsal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSucurrsal,FSucurrsal,SUbicacion")] Sucurrsal sucurrsal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucurrsal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sucurrsal);
        }

        // GET: Sucurrsal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sucurrsales == null)
            {
                return NotFound();
            }

            var sucurrsal = await _context.Sucurrsales.FindAsync(id);
            if (sucurrsal == null)
            {
                return NotFound();
            }
            return View(sucurrsal);
        }

        // POST: Sucurrsal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSucurrsal,FSucurrsal,SUbicacion")] Sucurrsal sucurrsal)
        {
            if (id != sucurrsal.IdSucurrsal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucurrsal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucurrsalExists(sucurrsal.IdSucurrsal))
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
            return View(sucurrsal);
        }

        // GET: Sucurrsal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sucurrsales == null)
            {
                return NotFound();
            }

            var sucurrsal = await _context.Sucurrsales
                .FirstOrDefaultAsync(m => m.IdSucurrsal == id);
            if (sucurrsal == null)
            {
                return NotFound();
            }

            return View(sucurrsal);
        }

        // POST: Sucurrsal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sucurrsales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sucurrsales'  is null.");
            }
            var sucurrsal = await _context.Sucurrsales.FindAsync(id);
            if (sucurrsal != null)
            {
                _context.Sucurrsales.Remove(sucurrsal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucurrsalExists(int id)
        {
          return (_context.Sucurrsales?.Any(e => e.IdSucurrsal == id)).GetValueOrDefault();
        }
    }
}
