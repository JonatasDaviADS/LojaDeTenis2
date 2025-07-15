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
    public class NotaFiscalController : Controller
    {
        private readonly LojaDeTenisContext _context;

        public NotaFiscalController(LojaDeTenisContext context)
        {
            _context = context;
        }

        // Lista todas as notas fiscais com cliente e pedido incluídos
        public async Task<IActionResult> Index()
        {
            var notaFiscal = await _context.NotaFiscal
                .Include(n => n.Cliente)
                .Include(n => n.Pedido)
                .ToListAsync();

            return View(notaFiscal);
        }


        // Exibe os detalhes de uma nota fiscal específica
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NotaFiscal == null)
            {
                return NotFound();
            }

            var notaFiscal = await _context.NotaFiscal
                .Include(n => n.Cliente)
                .Include(n => n.Pedido)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (notaFiscal == null)
            {
                return NotFound();
            }

            return View(notaFiscal);
        }

        // Carrega a view de criação de nova nota fiscal
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id");
            return View();
        }

        // Recebe os dados da nova nota fiscal e salva no banco
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Serie,ChaveAcesso,DataEmissao,ValorTotal,ClienteId,XmlNotaFiscal,Status")] NotaFiscal notaFiscal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaFiscal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", notaFiscal.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", notaFiscal.PedidoId);
            return View(notaFiscal);
        }

        // Carrega os dados de uma nota fiscal para edição
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NotaFiscal == null)
            {
                return NotFound();
            }

            var notaFiscal = await _context.NotaFiscal.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", notaFiscal.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", notaFiscal.PedidoId);
            return View(notaFiscal);
        }

        // Recebe os dados atualizados da nota fiscal e salva as alterações
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Serie,ChaveAcesso,DataEmissao,ValorTotal,PedidoId,ClienteId,XmlNotaFiscal,Status")] NotaFiscal notaFiscal)
        {
            if (id != notaFiscal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaFiscal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaFiscalExists(notaFiscal.Id))
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

            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", notaFiscal.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", notaFiscal.PedidoId);
            return View(notaFiscal);
        }

        // Carrega a confirmação de exclusão de uma nota fiscal
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NotaFiscal == null)
            {
                return NotFound();
            }

            var notaFiscal = await _context.NotaFiscal
                .Include(n => n.Cliente)
                .Include(n => n.Pedido)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (notaFiscal == null)
            {
                return NotFound();
            }

            return View(notaFiscal);
        }

        // Exclui a nota fiscal após confirmação
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NotaFiscal == null)
            {
                return Problem("Entity set 'LojaDeTenisContext.NotaFiscal' está nulo.");
            }

            var notaFiscal = await _context.NotaFiscal.FindAsync(id);
            if (notaFiscal != null)
            {
                _context.NotaFiscal.Remove(notaFiscal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Verifica se uma nota fiscal existe no banco
        private bool NotaFiscalExists(int id)
        {
            return _context.NotaFiscal?.Any(e => e.Id == id) ?? false;
        }
    }
}
