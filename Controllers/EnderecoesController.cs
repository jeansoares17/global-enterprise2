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
    public class EnderecoesController : Controller
    {
        private readonly OracleDbContext _context;

        public EnderecoesController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Enderecoes
        public async Task<IActionResult> Index()
        {
              return _context.Endereco != null ? 
                          View(await _context.Endereco.ToListAsync()) :
                          Problem("Entity set 'OracleDbContext.Endereco'  is null.");
        }

        // GET: Enderecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .FirstOrDefaultAsync(m => m.IdEndereco == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Enderecoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEndereco,CEP,Complemento,Bairro,Cidade,Estado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Enderecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEndereco,CEP,Complemento,Bairro,Cidade,Estado")] Endereco endereco)
        {
            if (id != endereco.IdEndereco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.IdEndereco))
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
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .FirstOrDefaultAsync(m => m.IdEndereco == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Endereco == null)
            {
                return Problem("Entity set 'OracleDbContext.Endereco'  is null.");
            }
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco != null)
            {
                _context.Endereco.Remove(endereco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
          return (_context.Endereco?.Any(e => e.IdEndereco == id)).GetValueOrDefault();
        }
    }
}
