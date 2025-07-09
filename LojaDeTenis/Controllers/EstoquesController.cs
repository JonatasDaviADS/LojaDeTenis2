using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDeTenis.Data;
using LojaDeTenis.Models;

namespace LojaDeTenis.Controllers
{
    public class EstoquesController : Controller
    {
        private readonly LojaDeTenisContext _context;

        public EstoquesController(LojaDeTenisContext context)
        {
            _context = context;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
            var lojaDeTenisContext = _context.Estoquee.Include(e => e.Produto);
            return View(await lojaDeTenisContext.ToListAsync());
        }

        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estoquee == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoquee
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoques/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id");
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,Quantidade,DataReabastecimento")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", estoque.ProdutoId);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estoquee == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoquee.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", estoque.ProdutoId);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,Quantidade,DataReabastecimento")] Estoque estoque)
        {
            if (id != estoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(estoque.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", estoque.ProdutoId);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estoquee == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoquee
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estoquee == null)
            {
                return Problem("Entity set 'LojaDeTenisContext.Estoque'  is null.");
            }
            var estoque = await _context.Estoquee.FindAsync(id);
            if (estoque != null)
            {
                _context.Estoquee.Remove(estoque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(int id)
        {
          return (_context.Estoquee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
