using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDeTenis.Data;
using LojaDeTenis.Models;
using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Controllers
{
    public class PagamentoesController : Controller
    {
        private readonly LojaDeTenisContext _context;

        public PagamentoesController(LojaDeTenisContext context)
        {
            _context = context;
        }

        // Método auxiliar para popular dropdown com enum e Display Name
        private SelectList ObterMetodosPagamentoSelectList(object? selecionado = null)
        {
            var valores = Enum.GetValues(typeof(MetodoPagamento))
                .Cast<MetodoPagamento>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.GetType()
                            .GetMember(e.ToString())
                            .First()
                            .GetCustomAttributes(false)
                            .OfType<DisplayAttribute>()
                            .FirstOrDefault()?.Name ?? e.ToString()
                });

            return new SelectList(valores, "Value", "Text", selecionado);
        }

        // GET: Pagamentoes
        public async Task<IActionResult> Index()
        {
            var lojaDeTenisContext = _context.Pagamento.Include(p => p.Pedido);
            return View(await lojaDeTenisContext.ToListAsync());
        }

        // GET: Pagamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamento == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamentoes/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.ProdPedi, "Id", "Id");
            ViewData["MetodoPagamento"] = ObterMetodosPagamentoSelectList();
            return View();
        }

        // POST: Pagamentoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidoId,Valor,DataPagamento,MetodoPagamento")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PedidoId"] = new SelectList(_context.ProdPedi, "Id", "Id", pagamento.PedidoId);
            ViewData["MetodoPagamento"] = ObterMetodosPagamentoSelectList(pagamento.MetodoPagamento);
            return View(pagamento);
        }

        // GET: Pagamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagamento == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            ViewData["PedidoId"] = new SelectList(_context.ProdPedi, "Id", "Id", pagamento.PedidoId);
            ViewData["MetodoPagamento"] = ObterMetodosPagamentoSelectList(pagamento.MetodoPagamento);
            return View(pagamento);
        }

        // POST: Pagamentoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,Valor,DataPagamento,MetodoPagamento")] Pagamento pagamento)
        {
            if (id != pagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.Id))
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

            ViewData["PedidoId"] = new SelectList(_context.ProdPedi, "Id", "Id", pagamento.PedidoId);
            ViewData["MetodoPagamento"] = ObterMetodosPagamentoSelectList(pagamento.MetodoPagamento);
            return View(pagamento);
        }

        // GET: Pagamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagamento == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamento == null)
            {
                return Problem("Entity set 'LojaDeTenisContext.Pagamento'  is null.");
            }

            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamento.Remove(pagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
            return (_context.Pagamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
