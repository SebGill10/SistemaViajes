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
    public class RegistroViajesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroViajesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroViajes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroViajes.Include(r => r.Sucursal).Include(r => r.Transportista);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroViajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroViajes == null)
            {
                return NotFound();
            }

            var registroViaje = await _context.RegistroViajes
                .Include(r => r.Sucursal)
                .Include(r => r.Transportista)
                .FirstOrDefaultAsync(m => m.IdRegistroViaje == id);
            if (registroViaje == null)
            {
                return NotFound();
            }

            return View(registroViaje);
        }

        // GET: RegistroViajes/Create
        public IActionResult Create()
        {
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal");
            ViewData["TransportistaId"] = new SelectList(_context.Transportistas, "IdTransportista", "FTransportista");
            return View();
        }

        // POST: RegistroViajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistroViaje,UsuarioId,SucursalId,TransportistaId,FechaViaje")] RegistroViaje registroViaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroViaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal", registroViaje.SucursalId);
            ViewData["TransportistaId"] = new SelectList(_context.Transportistas, "IdTransportista", "FTransportista", registroViaje.TransportistaId);
            return View(registroViaje);
        }

        // GET: RegistroViajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroViajes == null)
            {
                return NotFound();
            }

            var registroViaje = await _context.RegistroViajes.FindAsync(id);
            if (registroViaje == null)
            {
                return NotFound();
            }
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal", registroViaje.SucursalId);
            ViewData["TransportistaId"] = new SelectList(_context.Transportistas, "IdTransportista", "FTransportista", registroViaje.TransportistaId);
            return View(registroViaje);
        }

        // POST: RegistroViajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistroViaje,UsuarioId,SucursalId,TransportistaId,FechaViaje")] RegistroViaje registroViaje)
        {
            if (id != registroViaje.IdRegistroViaje)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroViaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroViajeExists(registroViaje.IdRegistroViaje))
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
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal", registroViaje.SucursalId);
            ViewData["TransportistaId"] = new SelectList(_context.Transportistas, "IdTransportista", "FTransportista", registroViaje.TransportistaId);
            return View(registroViaje);
        }

        // GET: RegistroViajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroViajes == null)
            {
                return NotFound();
            }

            var registroViaje = await _context.RegistroViajes
                .Include(r => r.Sucursal)
                .Include(r => r.Transportista)
                .FirstOrDefaultAsync(m => m.IdRegistroViaje == id);
            if (registroViaje == null)
            {
                return NotFound();
            }

            return View(registroViaje);
        }

        // POST: RegistroViajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroViajes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegistroViajes'  is null.");
            }
            var registroViaje = await _context.RegistroViajes.FindAsync(id);
            if (registroViaje != null)
            {
                _context.RegistroViajes.Remove(registroViaje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroViajeExists(int id)
        {
          return (_context.RegistroViajes?.Any(e => e.IdRegistroViaje == id)).GetValueOrDefault();
        }
    }
}
