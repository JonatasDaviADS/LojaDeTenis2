using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDeTenis.Data;
using LojaDeTenis.Models;
using LojaDeTenis.Models.ViewModels;

namespace LojaDeTenis.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly LojaDeTenisContext _context;

        public ProdutosController(LojaDeTenisContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lojaDeTenisContext = _context.Produto.Include(p => p.Categoria);
            return View(await lojaDeTenisContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produto == null)
                return NotFound();

            var produto = await _context.Produto
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            var viewModel = new ProdutoViewModel
            {
                Produto = new Produto(),
                Categorias = _context.Categoria
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome
                    }).ToList()
            };

            return View(viewModel);
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(viewModel.Produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recarregar categorias caso tenha erro
            viewModel.Categorias = _context.Categoria
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                }).ToList();

            return View(viewModel);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produto == null)
                return NotFound();

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
                return NotFound();

            var viewModel = new ProdutoViewModel
            {
                Produto = produto,
                Categorias = _context.Categoria
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome
                    }).ToList()
            };

            return View(viewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel viewModel)
        {
            if (id != viewModel.Produto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(viewModel.Produto.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            viewModel.Categorias = _context.Categoria
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produto == null)
                return NotFound();

            var produto = await _context.Produto
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produto == null)
                return Problem("Entity set 'LojaDeTenisContext.Produto' is null.");

            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
                _context.Produto.Remove(produto);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Produto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
