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
    public class AnterioresController : Controller
    {
        private readonly OracleDbContext _context;

        public AnterioresController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Anteriores
        public async Task<IActionResult> Index()
        {
              return _context.Anteriores != null ? 
                          View(await _context.Anteriores.ToListAsync()) :
                          Problem("Entity set 'OracleDbContext.Anteriores'  is null.");
        }

        // GET: Anteriores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anteriores == null)
            {
                return NotFound();
            }

            var anteriores = await _context.Anteriores
                .FirstOrDefaultAsync(m => m.IdRegistroAnteriores == id);
            if (anteriores == null)
            {
                return NotFound();
            }

            return View(anteriores);
        }

        // GET: Anteriores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anteriores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistroAnteriores,Data,NomeVacina,FaixaEtaria")] Anteriores anteriores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anteriores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anteriores);
        }

        // GET: Anteriores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anteriores == null)
            {
                return NotFound();
            }

            var anteriores = await _context.Anteriores.FindAsync(id);
            if (anteriores == null)
            {
                return NotFound();
            }
            return View(anteriores);
        }

        // POST: Anteriores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistroAnteriores,Data,NomeVacina,FaixaEtaria")] Anteriores anteriores)
        {
            if (id != anteriores.IdRegistroAnteriores)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anteriores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnterioresExists(anteriores.IdRegistroAnteriores))
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
            return View(anteriores);
        }

        // GET: Anteriores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anteriores == null)
            {
                return NotFound();
            }

            var anteriores = await _context.Anteriores
                .FirstOrDefaultAsync(m => m.IdRegistroAnteriores == id);
            if (anteriores == null)
            {
                return NotFound();
            }

            return View(anteriores);
        }

        // POST: Anteriores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anteriores == null)
            {
                return Problem("Entity set 'OracleDbContext.Anteriores'  is null.");
            }
            var anteriores = await _context.Anteriores.FindAsync(id);
            if (anteriores != null)
            {
                _context.Anteriores.Remove(anteriores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnterioresExists(int id)
        {
          return (_context.Anteriores?.Any(e => e.IdRegistroAnteriores == id)).GetValueOrDefault();
        }
    }
}
