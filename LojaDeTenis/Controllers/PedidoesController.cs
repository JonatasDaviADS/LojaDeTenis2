using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDeTenis.Data;
using LojaDeTenis.Models;

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
            ViewBag.Cliente = new SelectList(_context.Cliente, "Id", "Nome");
            ViewBag.Categoria = new SelectList(_context.Categoria, "Id", "Nome");
            return View();
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
            // ViewBag.Categoria = new SelectList(_context.Categoria, "Id", "Nome", pedido.CategoriaId);
            return View(pedido);
        }

        // Outros métodos como Index, Details, Edit, Delete, etc...
    }
}
