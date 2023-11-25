using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using global_enterprise.Data;
using global_enterprise.Entities;

namespace global_enterprise.Controllers
{
    public class StatusVacinasController : Controller
    {
        private readonly OracleDbContext _context;

        public StatusVacinasController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: StatusVacinas
        public async Task<IActionResult> Index()
        {
              return _context.StatusVacina != null ? 
                          View(await _context.StatusVacina.ToListAsync()) :
                          Problem("Entity set 'OracleDbContext.StatusVacina'  is null.");
        }

        // GET: StatusVacinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusVacina == null)
            {
                return NotFound();
            }

            var statusVacina = await _context.StatusVacina
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusVacina == null)
            {
                return NotFound();
            }

            return View(statusVacina);
        }

        // GET: StatusVacinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusVacinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatus,TipoStatus,Data,NumeroLote")] StatusVacina statusVacina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusVacina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusVacina);
        }

        // GET: StatusVacinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusVacina == null)
            {
                return NotFound();
            }

            var statusVacina = await _context.StatusVacina.FindAsync(id);
            if (statusVacina == null)
            {
                return NotFound();
            }
            return View(statusVacina);
        }

        // POST: StatusVacinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatus,TipoStatus,Data,NumeroLote")] StatusVacina statusVacina)
        {
            if (id != statusVacina.IdStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusVacina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusVacinaExists(statusVacina.IdStatus))
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
            return View(statusVacina);
        }

        // GET: StatusVacinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusVacina == null)
            {
                return NotFound();
            }

            var statusVacina = await _context.StatusVacina
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusVacina == null)
            {
                return NotFound();
            }

            return View(statusVacina);
        }

        // POST: StatusVacinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusVacina == null)
            {
                return Problem("Entity set 'OracleDbContext.StatusVacina'  is null.");
            }
            var statusVacina = await _context.StatusVacina.FindAsync(id);
            if (statusVacina != null)
            {
                _context.StatusVacina.Remove(statusVacina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusVacinaExists(int id)
        {
          return (_context.StatusVacina?.Any(e => e.IdStatus == id)).GetValueOrDefault();
        }
    }
}
