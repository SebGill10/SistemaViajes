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
    public class SucursalColaboradorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucursalColaboradorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SucursalColaboradors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SucursalColaboradores.Include(s => s.Colaborador).Include(s => s.Sucursal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SucursalColaboradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SucursalColaboradores == null)
            {
                return NotFound();
            }

            var sucursalColaborador = await _context.SucursalColaboradores
                .Include(s => s.Colaborador)
                .Include(s => s.Sucursal)
                .FirstOrDefaultAsync(m => m.SucursalId == id);
            if (sucursalColaborador == null)
            {
                return NotFound();
            }

            return View(sucursalColaborador);
        }

        // GET: SucursalColaboradors/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido");
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal");
            return View();
        }

        // POST: SucursalColaboradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,SucursalId,Distancia")] SucursalColaborador sucursalColaborador)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    _context.Add(sucursalColaborador);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido", sucursalColaborador.ColaboradorId);
                ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal", sucursalColaborador.SucursalId);
                return View(sucursalColaborador);

            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY"))
                {

                    ModelState.AddModelError("", "Error, este colaborador, ya tiene la sucursal asignada");
                }
                else
                {

                    ModelState.AddModelError("", "Error al ingresar la información, favor verifique.");
                }

                ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido", sucursalColaborador.ColaboradorId);
                ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal", sucursalColaborador.SucursalId);
                return View(sucursalColaborador);
            }




        }

        // GET: SucursalColaboradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SucursalColaboradores == null)
            {
                return NotFound();
            }

            var sucursalColaborador = await _context.SucursalColaboradores.FindAsync(id);
            if (sucursalColaborador == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido", sucursalColaborador.ColaboradorId);
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal", sucursalColaborador.SucursalId);
            return View(sucursalColaborador);
        }

        // POST: SucursalColaboradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,SucursalId,Distancia")] SucursalColaborador sucursalColaborador)
        {
            if (id != sucursalColaborador.SucursalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursalColaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalColaboradorExists(sucursalColaborador.SucursalId))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "IdColaborador", "Apellido", sucursalColaborador.ColaboradorId);
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "IdSucursal", "FSucursal", sucursalColaborador.SucursalId);
            return View(sucursalColaborador);
        }

        // GET: SucursalColaboradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SucursalColaboradores == null)
            {
                return NotFound();
            }

            var sucursalColaborador = await _context.SucursalColaboradores
                .Include(s => s.Colaborador)
                .Include(s => s.Sucursal)
                .FirstOrDefaultAsync(m => m.SucursalId == id);
            if (sucursalColaborador == null)
            {
                return NotFound();
            }

            return View(sucursalColaborador);
        }

        // POST: SucursalColaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SucursalColaboradores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SucursalColaboradores'  is null.");
            }
            var sucursalColaborador = await _context.SucursalColaboradores.FindAsync(id);
            if (sucursalColaborador != null)
            {
                _context.SucursalColaboradores.Remove(sucursalColaborador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalColaboradorExists(int id)
        {
            return (_context.SucursalColaboradores?.Any(e => e.SucursalId == id)).GetValueOrDefault();
        }
    }
}
