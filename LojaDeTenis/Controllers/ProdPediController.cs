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
    public class ProdPediController : Controller
    {
        private readonly LojaDeTenisContext _context;

        public ProdPediController(LojaDeTenisContext context)
        {
            _context = context;
        }

        // GET: ProdPedi
        public async Task<IActionResult> Index()
        {
            var lojaDeTenisContext = _context.ProdPedi.Include(p => p.Pedido).Include(p => p.Produto);
            return View(await lojaDeTenisContext.ToListAsync());
        }

        // GET: ProdPedi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProdPedi == null)
            {
                return NotFound();
            }

            var prodPedi = await _context.ProdPedi
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodPedi == null)
            {
                return NotFound();
            }

            return View(prodPedi);
        }

        // GET: ProdPedi/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id");
            return View();
        }

        // POST: ProdPedi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,PedidoId,Quantidade,PrecoUnitario")] ProdPedi prodPedi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodPedi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", prodPedi.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", prodPedi.ProdutoId);
            return View(prodPedi);
        }

        // GET: ProdPedi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProdPedi == null)
            {
                return NotFound();
            }

            var prodPedi = await _context.ProdPedi.FindAsync(id);
            if (prodPedi == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", prodPedi.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", prodPedi.ProdutoId);
            return View(prodPedi);
        }

        // POST: ProdPedi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,PedidoId,Quantidade,PrecoUnitario")] ProdPedi prodPedi)
        {
            if (id != prodPedi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodPedi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdPediExists(prodPedi.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", prodPedi.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", prodPedi.ProdutoId);
            return View(prodPedi);
        }

        // GET: ProdPedi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProdPedi == null)
            {
                return NotFound();
            }

            var prodPedi = await _context.ProdPedi
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodPedi == null)
            {
                return NotFound();
            }

            return View(prodPedi);
        }

        // POST: ProdPedi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProdPedi == null)
            {
                return Problem("Entity set 'LojaDeTenisContext.ProdPedi'  is null.");
            }
            var prodPedi = await _context.ProdPedi.FindAsync(id);
            if (prodPedi != null)
            {
                _context.ProdPedi.Remove(prodPedi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdPediExists(int id)
        {
          return (_context.ProdPedi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
