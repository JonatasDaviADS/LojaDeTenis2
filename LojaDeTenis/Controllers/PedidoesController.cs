using LojaDeTenis.Data;
using LojaDeTenis.Models;
using LojaDeTenis.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LojaDeTenis.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly LojaDeTenisContext _context;

        public PedidoesController(LojaDeTenisContext context)
        {
            _context = context;
        }

        // GET: Pedidos/Create

        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_context.Cliente, "Id", "Nome");
            return View(new Pedido());

            ListaProdutosViewModels ListaProdutos = new ListaProdutosViewModels
            {
                Produtos = _context.Produto.ToList()
            };
            return View(ListaProdutos);
        }

        //public IActionResult Create()
        //{
        //    //ViewBag.Cliente = new SelectList(_context.Cliente, "Id", "Nome");
        //    //return View();

        //    ListaProdutosViewModels ListaProdutos = new ListaProdutosViewModels
        //    {
        //        Produtos = _context.Produto.ToList()
        //    };
        //    return View(ListaProdutos);
        //}

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var pedidos = await _context.Pedido
                .Include(p => p.Cliente)
                .ToListAsync();

            return View(pedidos);
        }

        // POST: Pedidos/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ListaProdutosViewModels model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Pedido.Add(model.Pedido);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    model.Produtos = _context.Produto.ToList();
        //    ViewBag.Clientes = new SelectList(_context.Cliente, "Id", "Nome", model.Pedido.ClienteId);
        //    return View(model);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,ClienteId,Status")] Pedido pedido)
        {
            
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));           

            
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Data,ClienteId,CategoriaId,Status")] Pedido pedido)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pedido);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    ViewBag.Cliente = new SelectList(_context.Cliente, "Id", "Nome", pedido.ClienteId);
        //    return View(pedido);
        //}

        // Outros métodos como Index, Details, Edit, Delete, etc...
    }
}
