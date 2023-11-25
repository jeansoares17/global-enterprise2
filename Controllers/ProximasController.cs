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
    public class ProximasController : Controller
    {
        private readonly OracleDbContext _context;

        public ProximasController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Proximas
        public async Task<IActionResult> Index()
        {
              return _context.Proximas != null ? 
                          View(await _context.Proximas.ToListAsync()) :
                          Problem("Entity set 'OracleDbContext.Proximas'  is null.");
        }

        // GET: Proximas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proximas == null)
            {
                return NotFound();
            }

            var proximas = await _context.Proximas
                .FirstOrDefaultAsync(m => m.IdRegistroProximas == id);
            if (proximas == null)
            {
                return NotFound();
            }

            return View(proximas);
        }

        // GET: Proximas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proximas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistroProximas,Data,NomeVacina,FaixaEtaria,Recomendacoes")] Proximas proximas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proximas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proximas);
        }

        // GET: Proximas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proximas == null)
            {
                return NotFound();
            }

            var proximas = await _context.Proximas.FindAsync(id);
            if (proximas == null)
            {
                return NotFound();
            }
            return View(proximas);
        }

        // POST: Proximas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistroProximas,Data,NomeVacina,FaixaEtaria,Recomendacoes")] Proximas proximas)
        {
            if (id != proximas.IdRegistroProximas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proximas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProximasExists(proximas.IdRegistroProximas))
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
            return View(proximas);
        }

        // GET: Proximas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proximas == null)
            {
                return NotFound();
            }

            var proximas = await _context.Proximas
                .FirstOrDefaultAsync(m => m.IdRegistroProximas == id);
            if (proximas == null)
            {
                return NotFound();
            }

            return View(proximas);
        }

        // POST: Proximas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proximas == null)
            {
                return Problem("Entity set 'OracleDbContext.Proximas'  is null.");
            }
            var proximas = await _context.Proximas.FindAsync(id);
            if (proximas != null)
            {
                _context.Proximas.Remove(proximas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProximasExists(int id)
        {
          return (_context.Proximas?.Any(e => e.IdRegistroProximas == id)).GetValueOrDefault();
        }
    }
}
