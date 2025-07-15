using LojaDeTenis.Data;
using LojaDeTenis.Models;
using LojaDeTenis.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LojaDeTenis.Controllers
{
    public class PedidosController : Controller
    {
        private readonly LojaDeTenisContext _context;

        public PedidosController(LojaDeTenisContext context)
        {
            _context = context;
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            //ViewBag.Cliente = new SelectList(_context.Cliente, "Id", "Nome");
            //return View();

            ListaProdutosViewModels ListaProdutos = new ListaProdutosViewModels
            {
                Produtos = _context.Produto.ToList()
            };
            return View(ListaProdutos);
        }

        // POST: Pedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,ClienteId,CategoriaId,Status")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Cliente = new SelectList(_context.Cliente, "Id", "Nome", pedido.ClienteId);
            return View(pedido);
        }

        // Outros métodos como Index, Details, Edit, Delete, etc...
    }
}
